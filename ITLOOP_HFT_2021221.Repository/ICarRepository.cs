using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Repository
{
    public interface ICarRepository<T> where T : class 
    {
        public void Insert(T car);
        public void Remove(int id);
        public T Read(int id);
        public void Update(T car);
        public IQueryable<T> ReadAll();

    }
}
