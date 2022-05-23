let rentings = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30439/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RentingCreated", (user, message) => {
        getdata();
    });

    connection.on("RentingDeleted", (user, message) => {
        getdata();
    });

    connection.on("RentingUpdated", (user, message) => {
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
    await fetch('http://localhost:30439/renting')
        .then(x => x.json())
        .then(y => {
            rentings = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    rentings.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.amount + "</td><td>" +
            `<button type="button" onclick="Delete(${t.id})">Delete</button>` + `<button type="button" onclick="Update(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Update(id) {
    let name = document.getElementById('Renter_Name').value;
    let amount = document.getElementById('Renter_Amount').value;
    fetch('http://localhost:30439/renting', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: id, RenterName: name, Amount: amount })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function Delete(id) {
    fetch('http://localhost:30439/renting/' + id, {
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
    let name = document.getElementById('Renter_Name').value;
    let amount = document.getElementById('Renter_Amount').value;
    fetch('http://localhost:30439/renting', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { RenterName: name, Amount: amount })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

