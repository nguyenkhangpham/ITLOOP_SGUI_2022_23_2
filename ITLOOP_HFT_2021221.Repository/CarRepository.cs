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
    public class CarRepository : Repository<Car>, ICarRepository
    {
        AppDbContext dbc;
        public CarRepository(AppDbContext dbc): base(dbc)
        {
            this.dbc = dbc;
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
        public IQueryable<Car> ReadAll()
        {
            return dbc.Cars;
        }
        public Car Read(int id)
        {
            return
                dbc.Set<Car>().FirstOrDefault(t => t.CarID == id);
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
        public override void Remove(int id)
        {
            Car car = this.GetOne(id);
            this.Dbc.Set<Car>().Remove(car);
            this.Dbc.SaveChanges();
        }
        
    }
}
