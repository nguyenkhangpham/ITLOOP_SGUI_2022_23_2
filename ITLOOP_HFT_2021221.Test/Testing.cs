using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Repository;
using Moq;
using Newtonsoft.Json;
using ITLOOP_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;

namespace ITLOOP_HFT_2021221.Test
{
    [TestFixture]
    public class Tesing
    {
        private CarLogic cl { get; set; }
        private CarStoreLogic csl { get; set; }
        private RentingLogic rl { get; set; }
        private AppDbContext Context { get; set; }

        public void Setup()
        {
            Mock<ICarRepository<Car>> mockedCarRepo = new Mock<ICarRepository<Car>>();
            Mock<ICarStoreRepository<CarStore>> mockedCarStoreRepo = new Mock<ICarStoreRepository<CarStore>>();
            Mock<IRentingRepository<Renting>> mockedRentingRepo = new Mock<IRentingRepository<Renting>>();

            mockedCarRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Car()
                {
                    CarID = 1,
                    CarName = "Ferrari",
                    SellingPrice = 55000
                });
            mockedCarStoreRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new CarStore() //CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car"
                {
                    CarStoreID = 3,
                    Category = "Electric",
                    Infor = "Rental Electric car"
                });
            mockedRentingRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Renting() // RentID = 12, RenterName = "Mark Flynn", Amount = 1535
                {
                    RentID = 12,
                    RenterName = "Mark Flynn",
                    Amount = 1535
                });

            mockedCarRepo.Setup(x => x.ReadAll()).Returns(this.FakeCarObjects);
            mockedCarStoreRepo.Setup(x => x.ReadAll()).Returns(this.FakeCarStoreObjects);
            mockedRentingRepo.Setup(x => x.ReadAll()).Returns(this.FakeRentingObjects);

            this.cl = new CarLogic(mockedCarRepo.Object, mockedCarStoreRepo.Object, mockedRentingRepo.Object);
            this.csl = new CarStoreLogic(mockedCarRepo.Object, mockedCarStoreRepo.Object, mockedRentingRepo.Object);
            this.rl = new RentingLogic(mockedCarRepo.Object, mockedCarStoreRepo.Object, mockedRentingRepo.Object);
        }

        [SetUp]
        public void SetUp()
        {
            var contextBuilder = new DbContextOptionsBuilder<AppDbContext>();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            contextBuilder.UseSqlServer(connectionString);

            Context = new AppDbContext(contextBuilder.Options);


        }

        //[SetUp]
        //public void Init()
        //{
        //    var mockCarRepository =
        //        new Mock<ICarRepository>();

        //    CarStore carStore = new CarStore();
        //    carStore.CarStoreID = 1;
        //    carStore.Infor = "Electric";
        //    carStore.Category = "Rental Electric car";
        //    var cars = new List<Car>()
        //        {
        //            new Car(){
        //                CarID = 1,
        //                CarName = "Ferrari",
        //                SellingPrice = 55000
        //            },
        //            new Car(){
        //                CarID = 2,
        //                CarName = "Audi",
        //                SellingPrice = 85000
        //            }
        //        };

        //    mockCarRepository.Setup((t) => t.GetAll())
        //        .Returns((IQueryable<Car>)cars);

        //    cl = new CarLogic(
        //        mockCarRepository.Object);
        //}
        [Test]
        public void CreateNewCarTest()
        {
            //ARRANGE
            Car car1 = new Car() { CarID = 1, CarName = "Lamborgini", SellingPrice = 87693 };
            Car car2 = new Car() { CarID = 2, CarName = "Ferrari", SellingPrice = 35643 };
            Car car3 = new Car() { CarID = 3, CarName = "Toyota", SellingPrice = 64815 };

            ICarRepository<Car> repository = new CarRepository(Context);

            //ACT-ASSERT
            Assert.That(() => repository.Insert(car1), Throws.Nothing);
            Assert.That(() => repository.Insert(car2), Throws.InnerException);
            Assert.That(() => repository.Insert(car3), Throws.InnerException);
        }
        [Test]
        public void CreateNewCarStoreTest()
        {
            //ARRANGE
            CarStore car1 = new CarStore() { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car" };
            CarStore car2 = new CarStore() { CarStoreID = 2, Category = "Gasoline", Infor = "Rental Gasoline car" };
            CarStore car3 = new CarStore() { CarStoreID = 3, Category = "Sport", Infor = "Rental Sport car" };

            ICarStoreRepository<CarStore> repository = new CarStoreRepository(Context);

            //ACT-ASSERT
            Assert.That(() => repository.Insert(car1), Throws.Nothing);
            Assert.That(() => repository.Insert(car2), Throws.InnerException);
            Assert.That(() => repository.Insert(car3), Throws.InnerException);
        }
        [Test]
        public void CreateNewRentingTest()
        {
            //ARRANGE
            Renting r1 = new Renting() { RentID = 2, RenterName = "John Barnaby", Amount = 1220 };
            Renting r2 = new Renting() { RentID = 3, RenterName = "Annette Batchelor", Amount = 120 };
            Renting r3 = new Renting() { RentID = 4, RenterName = "Bill Bradbury", Amount = 2600 };

            IRentingRepository<Renting> repository = new RentingRepository(Context);

            //ACT-ASSERT
            Assert.That(() => repository.Insert(r1), Throws.Nothing);
            Assert.That(() => repository.Insert(r2), Throws.InnerException);
            Assert.That(() => repository.Insert(r3), Throws.InnerException);
        }
        [Test]
        public void GetInforOfNewCarsHaveIdHigherThan100Test()
        {
            //ACT
            var result = csl.GetInforOfNewCarsHaveIdHigherThan100();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Rental Electric car", 50)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public void GEtCarStoreIdHigherThan20Test()
        {
            //ACT
            var result = csl.GetCarStoreIdLessThan10();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Gasole", 10)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public void GetCarStoreIdLessThan10Test()
        {
            //ACT
            var result = csl.GetCarStoreIdLessThan10();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Electric", 1)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public void GetLowLevelCarTest()
        {
            //ACT
            var result = cl.GetLowLevelCar();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Toyota", 5000)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        /*
         public IEnumerable<int> GetCarStoreIdLessThan10();
        public IEnumerable<int> GEtCarStoreIdHigherThan20();
        public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100();
        */

        [Test]
        public void GetNormalLevelCarTest()
        {
            //ACT
            var result = cl.GetNormalLevelCar();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Ferrari", 25000)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public void GetHighLevelCarTest()
        {
            //ACT
            var result = cl.GetHighLevelCar();

            //ASSERT
            var list = new List
                <KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Audi", 150000)
            };
            Assert.That(result, Is.EqualTo(list));
        }
        [Test]
        public void Remove_ASubstring_RemovesThatSubstring()
        {
            string str = "Hello, world!";

            string transformed = str.Remove(1);

            var position = str.IndexOf("Hello");
            var expected = str.Substring(position + 5);
            Assert.AreEqual(expected, transformed);
        }
        [Test]
        public void Adding_4_And_3_Should_Return_7()
        {
            var calculator = new CarStore() { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car"};

            int result = calculator.CarStoreID;

            Assert.AreEqual(7, result);
        }

        Renting r0 = new Renting() { RentID = 1, RenterName = "Stan Smith", Amount = 350 };
        Renting r1 = new Renting() { RentID = 2, RenterName = "John Barnaby", Amount = 1220 };
        Renting r2 = new Renting() { RentID = 3, RenterName = "Annette Batchelor", Amount = 120 };

        private IQueryable<Car> FakeCarObjects()
        {
            Car car1 = new Car { CarID = 1, CarName = "Lamborgini", SellingPrice = 100000 };
            Car car2 = new Car { CarID = 2, CarName = "Honda", SellingPrice = 5000 };
            Car car3 = new Car { CarID = 3, CarName = "Hyundai", SellingPrice = 27300 };

            List<Car> carList = new List<Car>();

            carList.Add(car1);
            carList.Add(car2);
            carList.Add(car3);

            return carList.AsQueryable();
        }

        private IQueryable<CarStore> FakeCarStoreObjects()
        {
            CarStore car1 = new CarStore { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car" };
            CarStore car2 = new CarStore { CarStoreID = 2, Category = "Gasoline", Infor = "Rental Gasoline car" };
            CarStore car3 = new CarStore { CarStoreID = 3, Category = "Sport", Infor = "Rental Sport car" };

            List<CarStore> carStoreList = new List<CarStore>();

            carStoreList.Add(car1);
            carStoreList.Add(car2);
            carStoreList.Add(car3);

            return carStoreList.AsQueryable();
        }
        private IQueryable<Renting> FakeRentingObjects()
        {
            Renting car1 = new Renting { RentID = 1, RenterName = "Stan Smith", Amount = 350 };
            Renting car2 = new Renting { RentID = 2, RenterName = "John Barnaby", Amount = 1220 };
            Renting car3 = new Renting { RentID = 3, RenterName = "Annette Batchelor", Amount = 120 };

            List<Renting> rentingList = new List<Renting>();

            rentingList.Add(car1);
            rentingList.Add(car2);
            rentingList.Add(car3);

            return rentingList.AsQueryable();
        }

    }
}
