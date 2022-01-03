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
    public class RentingRepository : IRentingRepository<Renting>
    {
        AppDbContext dbc;
        public RentingRepository(AppDbContext _dbc)
        {
            this.dbc = _dbc;
        }
        //Create
        public  void Insert(Renting entity)
        {
            dbc.Set<Renting>().Add(entity);
            dbc.SaveChanges();
        }

        //Read
        public Renting Read(int id)
        {
            return
                dbc.Rentings.SingleOrDefault(t => t.Id == id);
        }

        //Update
        public void Update(Renting car)
        {
            var carToUpdate = Read(car.Id);
            carToUpdate.CarId = car.CarId;
            carToUpdate.RenterName = car.RenterName;
            carToUpdate.Amount = car.Amount;
            dbc.SaveChanges();
        }

        //Delete
        public void Remove(int id)
        {
            var toDelete = Read(id);
            dbc.Remove(toDelete);
            dbc.SaveChanges();
        }

        public IQueryable<Renting> ReadAll()
        {
            return dbc.Set<Renting>();
        }
    }
}
