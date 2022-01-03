using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Client
{
    class Program //old
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000);

            RestService restService = new("http://localhost:30439"); 

            bool exit1 = false;
            bool exit2;

            while (!exit1)
            {
                int userResponse;
                int id;
                Car car;
                CarStore carStore;
                Renting renting;

                Console.WriteLine("Welcome!\n");
                Console.WriteLine("Choose the kind of table:\n");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. CarStore");
                Console.WriteLine("3. Renting");
                Console.WriteLine("0. Exit application");

                userResponse = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (userResponse)
                {
                    case 1:
                        exit2 = false;
                        while (!exit2)
                        {
                            DefaultMenu();
                            Console.WriteLine("0. Exit\n");
                            userResponse = int.Parse(Console.ReadLine());
                            switch (userResponse)
                            {
                                case 1:
                                    Console.WriteLine("Enter the ID:");
                                    id = int.Parse(Console.ReadLine());
                                    car = restService.Get<Car>(id, "Car");
                                    Console.WriteLine(car.ToString());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.WriteLine("\n");
                                    var cars = restService.Get<Car>("Car");
                                    foreach (var obj in cars)
                                    {
                                        Console.WriteLine(obj.ToString());
                                    }
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.WriteLine("Adding new car to database\n");
                                    Console.WriteLine("Enter the car's name!");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter the car's price!");
                                    int sellingPrice = int.Parse(Console.ReadLine());
                                    restService.Post<Car>(new Car
                                    {
                                        CarName = name,
                                        SellingPrice = sellingPrice
                                    }, "Car");
                                    Console.WriteLine("Action successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 4:

                                    Console.WriteLine("Updating an existinging item\n");
                                    Console.WriteLine("Which car object would you like to update?");
                                    Console.WriteLine("Enter the car's id!");
                                    id = int.Parse(Console.ReadLine());
                                    car = restService.Get<Car>(id, "Car");
                                    Console.WriteLine("Enter the new car's name!");
                                    string Name = Console.ReadLine();
                                    Console.WriteLine("Enter the new car's price!");
                                    int CarSellingPrice = int.Parse(Console.ReadLine());

                                    car.CarName = Name;
                                    car.SellingPrice = CarSellingPrice;

                                    restService.Put<Car>(car, "Car");
                                    Console.WriteLine("\nThe updated details of the car:\n");
                                    Console.WriteLine(car.ToString());
                                    Console.WriteLine("\nPress any key to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 5:

                                    Console.WriteLine("Deleting an existinging item\n");
                                    Console.WriteLine("Which car would you like to delete from the database?");
                                    Console.WriteLine("Enter the car's id");
                                    id = int.Parse(Console.ReadLine());
                                    restService.Delete(id, "Car");
                                    Console.WriteLine("Action successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 0:
                                    exit2 = true;
                                    break;
                            }
                        }
                        break;

                    case 2:
                        exit2 = false;
                        while (!exit2)
                        {
                            DefaultMenu();
                            Console.WriteLine("0. Exit");
                            userResponse = int.Parse(Console.ReadLine());
                            switch (userResponse)
                            {
                                case 1:
                                    Console.WriteLine("Enter the ID:");
                                    id = int.Parse(Console.ReadLine());
                                    carStore = restService.Get<CarStore>(id, "CarStore");
                                    Console.WriteLine("\n" + carStore.ToString());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.WriteLine("\n");
                                    var carStores = restService.Get<CarStore>("CarStore");
                                    foreach (var obj in carStores)
                                    {
                                        Console.WriteLine(obj.ToString());
                                    }
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.WriteLine("Adding new carStore to database\n");
                                    Console.WriteLine("Enter its ID");
                                    id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter its name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter its category");
                                    string category = Console.ReadLine();
                                    Console.WriteLine("Enter its infor");
                                    string infor = Console.ReadLine();
                                    restService.Post<CarStore>(new CarStore
                                    {
                                        Name = name,
                                        Infor = infor,
                                        Category = category,
                                    }, "CarStore"); ; ;
                                    Console.WriteLine("\nAction successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 4:

                                    Console.WriteLine("Updating an existinging item\n");
                                    Console.WriteLine("Which carStore object would you like to update?");
                                    Console.WriteLine("Enter the carStore's id!");
                                    id = int.Parse(Console.ReadLine());
                                    carStore = restService.Get<CarStore>(id, "CarStore");
                                    Console.WriteLine("Enter the new category!");
                                    string carStorecategory = Console.ReadLine();
                                    Console.WriteLine("Enter the new infor!");
                                    string carStoreinfor = Console.ReadLine();

                                    carStore.Category = carStorecategory;
                                    carStore.Infor = carStoreinfor;

                                    restService.Put<CarStore>(carStore, "CarStore");
                                    Console.WriteLine("The updated details of the carStore:\n");
                                    Console.WriteLine(carStore.ToString()); 
                                    Console.WriteLine("\nPress any key to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 5:

                                    Console.WriteLine("Deleting an existinging item\n");
                                    Console.WriteLine("Which carStore would you like to delete from the database?");
                                    Console.WriteLine("Enter its id");
                                    id = int.Parse(Console.ReadLine());
                                    restService.Delete(id, "CarStore");
                                    Console.WriteLine("Action successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 0:
                                    exit2 = true;
                                    break;
                            }
                        }
                        break;

                    case 3:
                        exit2 = false;
                        while (!exit2)
                        {
                            DefaultMenu();
                            Console.WriteLine("0. Exit");
                            userResponse = int.Parse(Console.ReadLine());
                            switch (userResponse)
                            {
                                case 1:
                                    Console.WriteLine("Enter the ID:");
                                    id = int.Parse(Console.ReadLine());
                                    renting = restService.Get<Renting>(id, "Renting");
                                    Console.WriteLine(renting.ToString());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 2:
                                    var rentings = restService.Get<Renting>("Renting");
                                    foreach (var obj in rentings)
                                    {
                                        Console.WriteLine(obj.ToString());
                                    }
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.WriteLine("Adding new renting to database\n");
                                    Console.WriteLine("Enter its id");
                                    int rentingId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter its name");
                                    string rentingName = Console.ReadLine();
                                    Console.WriteLine("Enter its amount");
                                    int amount = int.Parse(Console.ReadLine());
                                    restService.Post<Renting>(new Renting
                                    {
                                        Id = rentingId,
                                        RenterName = rentingName,
                                        Amount = amount,

                                    }, "Renting");
                                    Console.WriteLine("Action successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 4:

                                    Console.WriteLine("Updating an existinging item\n");
                                    Console.WriteLine("Which renting object would you like to update?");
                                    Console.WriteLine("Enter the renting id!");
                                    id = int.Parse(Console.ReadLine());
                                    renting = restService.Get<Renting>(id, "Renting");
                                    Console.WriteLine("Enter the renting's id!");
                                    int rentOfId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the id of renting car:");
                                    int rentOfCarId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new name!");
                                    string rentOfName = Console.ReadLine();
                                    Console.WriteLine("Enter the new amount");
                                    int rentOfAmount = int.Parse(Console.ReadLine());

                                    renting.Id = rentOfId;
                                    renting.CarId = rentOfCarId;
                                    renting.RenterName = rentOfName;
                                    renting.Amount = rentOfAmount;


                                    restService.Put<Renting>(renting, "Renting");
                                    Console.WriteLine("The updated details of the renting:\n");
                                    Console.WriteLine(renting.ToString());
                                    Console.WriteLine("\nPress any key to continue");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 5:

                                    Console.WriteLine("Deleting an existinging item\n");
                                    Console.WriteLine("Which renting would you like to delete from the database?");
                                    Console.WriteLine("Enter its id");
                                    id = int.Parse(Console.ReadLine());
                                    restService.Delete(id, "Renting");
                                    Console.WriteLine("Action successful. \nPress any key to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 0:
                                    exit2 = true;
                                    break;
                            }
                        }
                        break;

                    case 0:
                        exit1 = true;
                        break;
                }
                Console.Clear();
            }
        }
        static void DefaultMenu()
        {
            Console.WriteLine("Choose the action!\n");
            Console.WriteLine("1. View a single item");
            Console.WriteLine("2. View all items");
            Console.WriteLine("3. Add a new item");
            Console.WriteLine("4. Update an existing item");
            Console.WriteLine("5. Delete an existing item");
        }

    }
}

