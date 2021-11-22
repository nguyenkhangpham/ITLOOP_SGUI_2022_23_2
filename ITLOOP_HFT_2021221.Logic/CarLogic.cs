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
    public class CarLogic : Repository<Car>, ICarRepository
    {
        public CarLogic(DbContext dbc) : base(dbc)
        {

        }
        //Create
        public override void Insert(Car entity)
        {
            this.dbc.Set<Car>().Add(entity);
        }

        //Read
        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CarID == id);
        }

        //Update
        public void ChangeInfor(int id, string newName)
        {
            var item = GetOne(id);
            item.CarName = newName;
            dbc.SaveChanges();
        }

        //Delete
        public override void Remove(int id)
        {
            Car car = this.GetOne(id);
            this.Dbc.Set<Car>().Remove(car);
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
