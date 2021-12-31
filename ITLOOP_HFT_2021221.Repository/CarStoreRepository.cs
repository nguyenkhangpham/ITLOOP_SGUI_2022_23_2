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
    public class CarStoreRepository : ICarStoreRepository<CarStore>
    {
        AppDbContext dbc;
        public CarStoreRepository(AppDbContext _dbc) 
        {
            this.dbc = _dbc;
        }
        public void Insert (CarStore entity)
        {
            this.dbc.Set<CarStore>().Add(entity);
        }
        //Read
        public CarStore Read(int id)
        {
            return
                dbc.Set<CarStore>().FirstOrDefault(t => t.CarStoreID == id);
        }

        //Update
        
        public void Update(CarStore car)
        {
            var carToUpdate = Read(car.CarStoreID);
            carToUpdate.Infor = car.Infor;
            carToUpdate.Category = car.Category;
            dbc.SaveChanges();
        }

        //Delete
        public  void Remove(int id)
        {
            var toDelete = Read(id);
            dbc.Remove(toDelete);
            dbc.SaveChanges();
        }
        public IQueryable<CarStore> ReadAll()
        {
            return dbc.CarStores;
        }
    }
}
