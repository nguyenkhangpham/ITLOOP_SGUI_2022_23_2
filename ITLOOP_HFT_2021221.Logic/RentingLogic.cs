using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;

namespace ITLOOP_HFT_2021221.Logic
{
    public class RentingLogic : IRentingLogic
    {
        ICarRepository carRepo;
        ICarStoreRepository carStoreRepo;
        IRentingRepository rentingRepo;
        public RentingLogic(IRentingRepository rentingRepo)
        {
            this.rentingRepo = rentingRepo;
        }
        public void Insert(Renting car)
        {
            rentingRepo.Insert(car);
        }

        public IEnumerable<Renting> GetAll()
        {
            return rentingRepo.GetAll();
        }

        public Renting Read(int id)
        {
            return rentingRepo.Read(id);
        }

        public void Remove(int id)
        {
            rentingRepo.Remove(id);
        }

        public void Update(Renting students)
        {
            rentingRepo.Update(students);
        }
        public IQueryable<Renting> ReadAll()
        {
            return rentingRepo.ReadAll();
        }
        public IEnumerable<int> GetRentAmountLessThan10000()
        {
            List<int> list = new List<int>();

            var car = from p in rentingRepo.ReadAll()
                      where p.Amount < 10000
                      select p.Amount;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetRentAmountHigherThan20000()
        {
            List<int> list = new List<int>();

            var car = from p in rentingRepo.ReadAll()
                      where p.Amount > 20000
                      select p.Amount;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetCarIdHasAmountLessThan10000()
        {
            List<int> list = new List<int>();

            var car = from x in rentingRepo.ReadAll()
                      join y in carRepo.ReadAll()
                      on x.CarID equals y.CarID
                      where x.Amount < 10000
                      select y.CarID;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<int> GetCarIdHasAmountHigherThan20000()
        {
            List<int> list = new List<int>();

            var car = from x in rentingRepo.ReadAll()
                      join y in carRepo.ReadAll()
                      on x.CarID equals y.CarID
                      where x.Amount >20000
                      select y.CarID;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
        public IEnumerable<string> GetCarNameHasAmountHigherThan10000()
        {
            List<string> list = new List<string>();

            var car = from x in rentingRepo.ReadAll()
                      join y in carRepo.ReadAll()
                      on x.CarID equals y.CarID
                      where x.Amount > 10000
                      select y.CarName;

            foreach (var item in car)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
