using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Repository
{
    class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext dbc): base(dbc)
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
    }
}
