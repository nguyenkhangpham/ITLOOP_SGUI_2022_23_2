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
        [SetUp]
        public void Setup()
        {
            Mock<ICarRepository<Car>> mockedCarRepo = new Mock<ICarRepository<Car>>();
            Mock<ICarStoreRepository<CarStore>> mockedCarStoreRepo = new Mock<ICarStoreRepository<CarStore>>();
            Mock<IRentingRepository<Renting>> mockedRentingRepo = new Mock<IRentingRepository<Renting>>();

            mockedCarRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Car()
                {
                    Id = 1,
                    CarName = "Ferrari",
                    SellingPrice = 55000
                });
            mockedCarStoreRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new CarStore() //CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car"
                {
                    Id = 3,
                    Category = "Electric",
                    Infor = "Rental Electric car"
                });
            mockedRentingRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new Renting() // RentID = 12, RenterName = "Mark Flynn", Amount = 1535
                {
                    Id = 12,
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

        [Test]
        public void CreateNewCarTest()
        {
            //ARRANGE
            Car car1 = new Car() { Id = 1, CarName = "Lamborgini", SellingPrice = 87693 };
            Car car2 = new Car() { Id = 2, CarName = "Ferrari", SellingPrice = 35643 };
            Car car3 = new Car() { Id = 3, CarName = "Toyota", SellingPrice = 64815 };

            //ACT-ASSERT
            Assert.That(() => cl.InsertCar(car1), Throws.Nothing);
            Assert.That(() => cl.InsertCar(car2), Throws.InnerException);
            Assert.That(() => cl.InsertCar(car3), Throws.InnerException);
        }
        [TestCase(1, "Ferrari", 81241)]
        [TestCase(5, "Audi", 15350)]
        [TestCase(2, "Honda", 25000)]
        public void CreateCar_DoesNotThrowException(int id, string name, int price)
        {
            Car car = new Car()
            { Id = id, CarName = name, SellingPrice = price };  
            Assert.That(() => cl.InsertCar(car), Throws.Nothing);
        }

        [TestCase(1, "Electric", "Rental Electric car")]
        [TestCase(5, "Gasoline", "Rental Gasoline car")]
        [TestCase(2, "Sport", "Rental Sport car")]
        public void CreateCarStore_DoesNotThrowException(int id, string cate, string infor)
        {
            CarStore car = new CarStore()
            { Id = id, Category = cate, Infor = infor };
            Assert.That(() => csl.Insert(car), Throws.Nothing);
        }

        [TestCase(1, "Electric", 34554)]
        [TestCase(5, "Gasoline", 25837)]
        [TestCase(2, "Sport", 73873)]
        public void CreateRenting_DoesNotThrowException(int id, string name, int amount)
        {
            Renting car = new Renting()
            { Id = id, RenterName = name, Amount = amount };
            Assert.That(() => rl.Insert(car), Throws.Nothing);
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
            var result = csl.GEtCarStoreIdHigherThan20();

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
            Assert.That(result.SingleOrDefault, Is.EqualTo(3));
        }

        [Test]
        public void GetNormalLevelCarTest()
        {
            //ACT
            var result = cl.GetNormalLevelCar();

            //ASSERT
            Assert.That(result.SingleOrDefault, Is.EqualTo(2));
        }
        [Test]
        public void GetHighLevelCarTest()
        {
            //ACT
            var result = cl.GetHighLevelCar();

            //ASSERT
            Assert.That(result.FirstOrDefault, Is.EqualTo(1));  
        }
        [Test]
        public void HighestAmountTest()
        {
            var item = this.rl.HighestAmount();
            Assert.That(item.Amount, Is.EqualTo(1220));
        }
        [Test]
        public void CarByName()
        {
            IEnumerable<Car> carItem = this.cl.CarWithSpecifyName("ferrari");
            foreach (var obj in carItem)
            {
                Assert.That(obj.CarName == "ferrari");
            }
        }

        private IQueryable<Car> FakeCarObjects()
        {
            Car car1 = new Car { Id = 1, CarName = "Lamborgini", SellingPrice = 100000 };
            Car car2 = new Car { Id = 2, CarName = "Honda", SellingPrice = 5000 };
            Car car3 = new Car { Id = 3, CarName = "Hyundai", SellingPrice = 27300 };

            List<Car> carList = new List<Car>();

            carList.Add(car1);
            carList.Add(car2);
            carList.Add(car3);

            return carList.AsQueryable();
        }

        private IQueryable<CarStore> FakeCarStoreObjects()
        {
            CarStore car1 = new CarStore { Id = 1, Category = "Electric", Infor = "Rental Electric car" };
            CarStore car2 = new CarStore { Id = 2, Category = "Gasoline", Infor = "Rental Gasoline car" };
            CarStore car3 = new CarStore { Id = 3, Category = "Sport", Infor = "Rental Sport car" };

            List<CarStore> carStoreList = new List<CarStore>();

            carStoreList.Add(car1);
            carStoreList.Add(car2);
            carStoreList.Add(car3);

            return carStoreList.AsQueryable();
        }
        private IQueryable<Renting> FakeRentingObjects()
        {
            Renting car1 = new Renting { Id = 1, RenterName = "Stan Smith", Amount = 350 };
            Renting car2 = new Renting { Id = 2, RenterName = "John Barnaby", Amount = 1220 };
            Renting car3 = new Renting { Id = 3, RenterName = "Annette Batchelor", Amount = 120 };

            List<Renting> rentingList = new List<Renting>();

            rentingList.Add(car1);
            rentingList.Add(car2);
            rentingList.Add(car3);

            return rentingList.AsQueryable();
        }

    }
}
