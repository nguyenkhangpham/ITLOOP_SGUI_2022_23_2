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
    public class CarStoreLogic : Logic, ICarStoreLogic
    {
        CarStoreLogic carStore;
        Car car;
        Renting renting;
        public CarStoreLogic(DbContext dbc) 
        {
            this.car = car;
            this.carStore = carStore;
            this.renting = renting;
        }
        public override void Insert(CarStore entity)
        {
            this.Dbc.Set<CarStore>().Add(entity);
        }
        //Read
        public override CarStore GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CarStoreID == id);
        }

        //Update
        public void ChangeInfor(int id, string newInfor)
        {
            var carStore = GetOne(id);
            carStore.Infor = newInfor;
            dbc.SaveChanges();
        }

        public void ChangeCategory(int id, string newCategory)
        {
            var carStore = GetOne(id);
            carStore.Category = newCategory;
            dbc.SaveChanges();
        }

        //Delete
        public override void Remove(int id)
        {
            CarStore cars = this.GetOne(id);
            this.Dbc.Set<CarStore>().Remove(cars);
            this.Dbc.SaveChanges();
        }
        public IEnumerable<int> GetIdPeopleRentingCar()
        {
            List<int> list = new List<int>();



            //foreach (var item in c)
            //{
            //    if()
            //    Console.WriteLine(item);
            //    list.Add(item);
            //}

            return list;

        }
        public IEnumerable<int> GetNumberOfAvailbleRentingCar()
        {
            List<int> list = new List<int>();



            //foreach (var item in c)
            //{
            //    if()
            //    Console.WriteLine(item);
            //    list.Add(item);
            //}

            return list;

        }
        public IEnumerable<string> GetNameOfCar()
        {
            List<string> list = new List<string>();



            //foreach (var item in c)
            //{
            //    if()
            //    Console.WriteLine(item);
            //    list.Add(item);
            //}

            return list;

        }
        public IEnumerable<int> GetIdPeopleRentingCarLater()
        {
            List<int> list = new List<int>();



            //foreach (var item in c)
            //{
            //    if()
            //    Console.WriteLine(item);
            //    list.Add(item);
            //}

            return list;

        }
        public IEnumerable<int> GetIdPeopleBooking()
        {
            List<int> list = new List<int>();



            //foreach (var item in c)
            //{
            //    if()
            //    Console.WriteLine(item);
            //    list.Add(item);
            //}

            return list;

        }
    }
}
