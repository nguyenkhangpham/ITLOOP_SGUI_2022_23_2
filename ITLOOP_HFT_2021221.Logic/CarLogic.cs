using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic<Car>
    {
        private ICarRepository<Car> carRepo;
        private ICarStoreRepository<CarStore> carStoreRepo;
        private IRentingRepository<Renting> rentingRepo;
        public CarLogic(ICarRepository<Car> _carRepo, ICarStoreRepository<CarStore> _carStoreRepo, IRentingRepository<Renting> _rentingRepo)
        {
            carRepo = _carRepo;
            carStoreRepo = _carStoreRepo;
            rentingRepo = _rentingRepo;
        }
        public void InsertCar(Car car)
        {
            carRepo.Insert(car);
        }


        public Car Read(int id)
        {
            return carRepo.Read(id);
        }

        public void Remove(int id)
        {
            carRepo.Remove(id);
        }

        public void Update(Car students)
        {
            carRepo.Update(students);
        }
        public IEnumerable  <Car> ReadAll()
        {
            return carRepo.ReadAll();
        }
        public IEnumerable<int> GetHighLevelCar()
        {
            List<int> list = new List<int>();

            var car = from p in carRepo.ReadAll()
                      where p.SellingPrice>80000
                      select p.Id;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetNormalLevelCar()
        {
            List<int> list = new List<int>();

            var car = from p in carRepo.ReadAll()
                      where p.SellingPrice > 30000 && p.SellingPrice < 80000
                      select p.Id;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetLowLevelCar()
        {
            List<int> list = new List<int>();

            var car = from p in carRepo.ReadAll()
                      where p.SellingPrice < 30000
                      select p.Id;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<string> GetCategoryInCarStore()
        {
            List<string> list = new List<string>();

            var car = from x in carRepo.ReadAll()
                      join y in carStoreRepo.ReadAll()
                      on x.CarStoreID equals y.Id
                      select y.Category;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetAmountOfRenting()
        {
            List<int> list = new List<int>();

            var car = from x in carRepo.ReadAll()
                      join y in rentingRepo.ReadAll()
                      on x.Id equals y.CarId
                      select y.Amount;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<Car> CarWithSpecifyName(string name)
        {
            return carRepo.ReadAll().Where(x => x.CarName.Equals(name));
        }


    }
}
