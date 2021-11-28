using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Repository
{
    public class RentingRepository : Repository<Renting>, IRentingRepository
    {
        public RentingRepository(DbContext dbc):base(dbc)
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
            var rent = GetOne(id);
            rent.Amount = newAmount;
            dbc.SaveChanges();
        }

        public void ChangeBidderName(int id, string NewName)
        {
            var rent = GetOne(id);
            rent.RenterName = NewName;
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
