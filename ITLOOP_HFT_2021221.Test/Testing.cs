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
        CarLogic cl;
        CarStoreLogic csl;
        RentingLogic rl;
        private AppDbContext Context { get; set; }
        [SetUp]
        public void SetUp()
        {
            var contextBuilder = new DbContextOptionsBuilder<AppDbContext>();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            contextBuilder.UseSqlServer(connectionString);

            Context = new AppDbContext(contextBuilder.Options);


        }

        [SetUp]
        public void Init()
        {
            var mockCarRepository =
                new Mock<ICarRepository>();

            CarStore carStore = new CarStore();
            carStore.CarStoreID = 1;
            carStore.Infor = "Electric";
            carStore.Category = "Rental Electric car";
            var cars = new List<Car>()
                {
                    new Car(){
                        CarID = 1,
                        CarName = "Ferrari",
                        SellingPrice = 55000
                    },
                    new Car(){
                        CarID = 2,
                        CarName = "Audi",
                        SellingPrice = 85000
                    }
                };

            mockCarRepository.Setup((t) => t.GetAll())
                .Returns((IQueryable<Car>)cars);

            cl = new CarLogic(
                mockCarRepository.Object);
        }
        [Test]
        public void CreateNewCarTest()
        {
            //ARRANGE
            Car car1 = new Car() { CarID = 1, CarName = "Lamborgini", SellingPrice = 87693 };
            Car car2 = new Car() { CarID = 2, CarName = "Ferrari", SellingPrice = 35643 };
            Car car3 = new Car() { CarID = 3, CarName = "Toyota", SellingPrice = 64815 };

            ICarRepository repository = new CarRepository(Context);

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

            ICarStoreRepository repository = new CarStoreRepository(Context);

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

            IRentingRepository repository = new RentingRepository(Context);

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

    }
}
