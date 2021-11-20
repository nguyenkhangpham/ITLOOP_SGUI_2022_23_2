﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Repository
{
    public class CarStoreRepository : Repository<CarStore>, ICarStoreRepository
    {
        public CarStoreRepository(DbContext dbc) : base(dbc)
        {

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
    }
}