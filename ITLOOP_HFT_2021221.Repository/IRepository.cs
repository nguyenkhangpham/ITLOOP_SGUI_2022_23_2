using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id); //read
        public IQueryable<T> GetAll();
    }

}
