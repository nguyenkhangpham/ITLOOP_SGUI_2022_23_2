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
        IQueryable<T> GetAll();
        void Insert(T entity); //create
        void Remove(int id); // delete
    }
    public interface ICarStoreRepository : IRepository<CarStore>
    {
        void ChangeInfor(int id, string newInfor);
        void ChangeCategory(int id, string newCategory);
    }
    public interface ICarRepository : IRepository<Car>
    {
        void ChangeInfor(int id, string newInfor);
    }
    public interface IRentingRepository : IRepository<Renting>
    {
        void ChangeAmount(int id, int newAmount);
    }

}
