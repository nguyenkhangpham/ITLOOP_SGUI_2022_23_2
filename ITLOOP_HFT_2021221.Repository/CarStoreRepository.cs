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
    public class CarStoreRepository : Repository<CarStore>, ICarStoreRepository
    {
        AppDbContext dbc;
        public CarStoreRepository(AppDbContext dbc) : base(dbc)
        {
            this.dbc = dbc;
        }
        public override void Insert (CarStore entity)
        {
            this.Dbc.Set<CarStore>().Add(entity);
        }
        //Read
        public override CarStore GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CarStoreID == id);
        }
        public CarStore Read(int id)
        {
            return
                dbc.Set<CarStore>().FirstOrDefault(t => t.CarStoreID == id);
        }

        //Update
        public void ChangeInfor(int id, string newInfor)
        {
            var carStore = GetOne(id);
            carStore.Infor = newInfor;
            dbc.SaveChanges();
        }
        public void ChangeOnlyId(int id)
        {
            var item = GetOne(id);
            dbc.SaveChanges();
        }

        public void ChangeCategory(int id, string newCategory)
        {
            var carStore = GetOne(id);
            carStore.Category = newCategory;
            dbc.SaveChanges();
        }
        public void Update(CarStore car)
        {
            var carToUpdate = Read(car.CarStoreID);
            carToUpdate.Infor = car.Infor;
            carToUpdate.Category = car.Category;
            dbc.SaveChanges();
        }

        //Delete
        public override void Remove(int id)
        {
            CarStore cars = this.GetOne(id);
            this.Dbc.Set<CarStore>().Remove(cars);
            this.Dbc.SaveChanges();
        }
        public IQueryable<CarStore> ReadAll()
        {
            return dbc.CarStores;
        }
    }
}
