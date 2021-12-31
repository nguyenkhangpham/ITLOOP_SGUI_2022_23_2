using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Repository
{
    public interface IRentingRepository<T> where T : class
    {
        //public void ChangeAmount(int id, int newAmount);

        public void Insert(Renting renting);
        public void Remove(int id);
        public void Update(Renting renting);

        public Renting Read(int id);
        public IQueryable<Renting> ReadAll();

    }
}
