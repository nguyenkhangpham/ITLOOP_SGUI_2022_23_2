using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Repository
{
    public interface ICarStoreRepository<T> where T : class
    {
        //public void ChangeInfor(int id, string newInfor);
        //public void ChangeCategory(int id, string newCategory);

        public void Insert(CarStore carStore);
        public void Remove(int id);
        public CarStore Read(int id);
        public void Update(CarStore carStore);
        public IQueryable<CarStore> ReadAll();


    }
}
