let carstores = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30439/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarStoreCreated", (user, message) => {
        getdata();
    });

    connection.on("CarStoreDeleted", (user, message) => {
        getdata();
    });

    connection.on("CarStoreUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:30439/carstore')
        .then(x => x.json())
        .then(y => {
            orders = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    carstores.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.infor + "</td><td>" + t.category + "</td><td>" +
            `<button type="button" onclick="Delete(${t.id})">Delete</button>` + `<button type="button" onclick="Update(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Update(id) {
    let name = document.getElementById('Carstore_Name').value;
    let infor = document.getElementById('Carstore_Infor').value;
    let category = document.getElementById('Carstore_Category').value;
    fetch('http://localhost:30439/carstore', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: id, Name: name, Infor: infor, Category: category })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function Delete(id) {
    fetch('http://localhost:30439/carstore/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ Id: id })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('Carstore_Name').value;
    let infor = document.getElementById('Carstore_Infor').value;
    let category = document.getElementById('Carstore_Category').value;

    fetch('http://localhost:30439/order', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Infor: infor, Category: category })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

