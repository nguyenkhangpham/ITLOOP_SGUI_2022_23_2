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
    public class CarStoreLogic : ICarStoreLogic<CarStore>
    {
        private ICarRepository<Car> carRepo;
        private ICarStoreRepository<CarStore> carStoreRepo;
        private IRentingRepository<Renting> rentingRepo;

        public CarStoreLogic(ICarRepository<Car> _carRepo, ICarStoreRepository<CarStore> _carStoreRepo, IRentingRepository<Renting> _rentingRepo)
        {
            carRepo = _carRepo;
            carStoreRepo = _carStoreRepo;
            rentingRepo = _rentingRepo;
        }
        public void Insert(CarStore car)
        {
            carStoreRepo.Insert(car);
        }

        public CarStore Read(int id)
        {
            return carStoreRepo.Read(id);
        }

        public void Remove(int id)
        {
            carStoreRepo.Remove(id);
        }

        public void Update(CarStore students)
        {
            carStoreRepo.Update(students);
        }
        public IQueryable<CarStore> ReadAll()
        {
            return carStoreRepo.ReadAll();
        }
        public IEnumerable<int> GetCarStoreIdLessThan10()
        {
            List<int> list = new List<int>();

            var car = from p in carStoreRepo.ReadAll()
                      where p.CarStoreID < 10
                      select p.CarStoreID;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        
            public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100()
        {
            List<string> list = new List<string>();

            var car = from p in carStoreRepo.ReadAll()
                      where p.CarStoreID > 100
                      select p.Infor;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GEtCarStoreIdHigherThan20()
        {
            List<int> list = new List<int>();

            var car = from p in carStoreRepo.ReadAll()
                      where p.CarStoreID > 20
                      select p.CarStoreID;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<string> GetCarNameDetail()
        {
            List<string> list = new List<string>();

            var car = from x in carStoreRepo.ReadAll()
                      join y in carRepo.ReadAll()
                      on x.CarStoreID equals y.CarStoreID
                      select y.CarName;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<string> GetCategoryElectricCar()
        {
            List<string> list = new List<string>();

            var car = from x in carStoreRepo.ReadAll()
                      where x.Category == "Electric"
                      select x.Category;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
