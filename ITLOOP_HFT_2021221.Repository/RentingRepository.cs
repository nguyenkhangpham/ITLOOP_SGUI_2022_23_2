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
    public class RentingRepository : Repository<Renting>, IRentingRepository
    {
        AppDbContext dbc;
        public RentingRepository(AppDbContext dbc):base(dbc)
        {
            this.dbc = dbc;
        }
        //Create
        public override void Insert(Renting entity)
        {
            this.dbc.Set<Renting>().Add(entity);
        }

        //Read
        public Renting Read(int id)
        {
            return
                dbc.Set<Renting>().FirstOrDefault(t => t.RentID == id);
        }
        public override Renting GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.RentID == id);
        }

        //Update
        public void Update(Renting car)
        {
            var carToUpdate = Read(car.RentID);
            carToUpdate.RenterName = car.RenterName;
            carToUpdate.Amount = car.Amount;
            carToUpdate.CarID = car.CarID;
            carToUpdate.Car = car.Car;
            dbc.SaveChanges();
        }
        //public void ChangeAmount(int id, int newAmount)
        //{
        //    var rent = GetOne(id);
        //    rent.Amount = newAmount;
        //    dbc.SaveChanges();
        //}

        //public void ChangeBidderName(int id, string NewName)
        //{
        //    var rent = GetOne(id);
        //    rent.RenterName = NewName;
        //    dbc.SaveChanges();
        //}

        //Delete
        public override void Remove(int id)
        {
            Renting rent = this.GetOne(id);
            this.Dbc.Set<Renting>().Remove(rent);
            this.Dbc.SaveChanges();
        }

        public IQueryable<Renting> ReadAll()
        {
            return dbc.Rentings;
        }
    }
}
