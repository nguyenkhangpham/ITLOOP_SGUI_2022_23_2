using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Data;

namespace ITLOOP_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository<Car>
    {
        AppDbContext dbc;
        public CarRepository(AppDbContext _dbc)
        {
            this.dbc = _dbc;
        }
        //Create
        public void Insert(Car entity)
        {
           dbc.Set<Car>().Add(entity);
            dbc.SaveChanges();
        }
        //Read
        
        public IQueryable<Car> ReadAll()
        {
            return dbc.Cars;
        }
        public Car Read(int id)
        {
            return
                dbc.Set<Car>().SingleOrDefault(t => t.CarID == id);
        }

        //Update
        public void Update(Car car)
        {
            var carToUpdate = Read(car.CarID);
            carToUpdate.CarName = car.CarName;
            carToUpdate.CarStore = car.CarStore;
            carToUpdate.SellingPrice = car.SellingPrice;
            dbc.SaveChanges();
        }
        //public void ChangeInfor(int id, string newName)
        //{
        //    var item = GetOne(id);
        //    item.CarName = newName;
        //    dbc.SaveChanges();
        //}
        //public void ChangeOnlyId(int id)
        //{
        //    var item = GetOne(id);
        //    dbc.SaveChanges();
        //}

        //Delete
        public void Remove(int id)
        {
            var toDelete = Read(id);
            dbc.Remove(toDelete);

            dbc.SaveChanges();
        }
        
    }
}
