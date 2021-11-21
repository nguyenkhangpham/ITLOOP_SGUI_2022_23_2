using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;


namespace ITLOOP_HFT_2021221.Logic
{
    public interface ILogic<T> where T: class
    {
        T GetOne(int id); //read
        IEnumerable<T> GetAll();
        void Insert(T entity); //create
        void Remove(int id); // delete
        //public void Create();
        //public void Read();
        //public void Update();
        //public void Delete();
    }
    public interface ICarStoreLogic : ILogic<CarStore>
    {
        void ChangeInfor(int id, string newInfor);
        void ChangeCategory(int id, string newCategory);
    }
    public interface ICarLogic : ILogic<Car>
    {
        void ChangeInfor(int id, string newInfor);
    }
    public interface IRentingLogic : ILogic<Renting>
    {
        void ChangeAmount(int id, int newAmount);
    }

}
