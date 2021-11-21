using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;

namespace ITLOOP_HFT_2021221.Logic
{
    public class RentingLogic : Repository<Car>, ICarRepository
    {
        public RentingLogic(DbContext dbc) : base(dbc)
        {

        }
        //Create
        public override void Insert(Renting entity)
        {
            this.dbc.Set<Renting>().Add(entity);
        }

        //Read
        public override Renting GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.RentID == id);
        }

        //Update
        public void ChangeAmount(int id, int newAmount)
        {
            var bid = GetOne(id);
            bid.Amount = newAmount;
            dbc.SaveChanges();
        }

        public void ChangeBidderName(int id, string NewName)
        {
            var bid = GetOne(id);
            bid.RenterName = NewName;
            dbc.SaveChanges();
        }

        //Delete
        public override void Remove(int id)
        {
            Renting rent = this.GetOne(id);
            this.Dbc.Set<Renting>().Remove(rent);
            this.Dbc.SaveChanges();
        }
    }
}
