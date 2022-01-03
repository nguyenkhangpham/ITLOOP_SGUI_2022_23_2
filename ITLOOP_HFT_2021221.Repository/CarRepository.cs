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
            return dbc.Set<Car>();
        }
        public Car Read(int id)
        {
            return
                dbc.Cars.SingleOrDefault(t => t.Id == id);
        }

        //Update
        public void Update(Car car)
        {
            var carToUpdate = Read(car.Id);
            carToUpdate.CarName = car.CarName;
            carToUpdate.SellingPrice = car.SellingPrice;
            dbc.SaveChanges();
        }

        //Delete
        public void Remove(int id)
        {
            var toDelete = Read(id);
            dbc.Remove(toDelete);

            dbc.SaveChanges();
        }
        
    }
}
