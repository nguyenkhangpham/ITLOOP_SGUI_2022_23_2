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
    public interface ICarStoreRepository : IRepository<CarStore>
    {
        //public void ChangeInfor(int id, string newInfor);
        //public void ChangeCategory(int id, string newCategory);
        public void Insert(CarStore carStore);
        public void Remove(int id);
        public CarStore Read(int id);
        public void Update(CarStore carStore);
        public IQueryable<CarStore> ReadAll();


    }
    public interface ICarRepository : IRepository<Car>
    {
        //public void ChangeInfor(int id, string newInfor);
        public void Insert(Car car);
        public void Remove(int id);
        public Car Read(int id);
        public void Update(Car car);
        public IQueryable<Car> ReadAll();

    }
    public interface IRentingRepository : IRepository<Renting>
    {
        //public void ChangeAmount(int id, int newAmount);
        public void Insert(Renting renting);
        public void Remove(int id);
        public void Update(Renting renting);

        public Renting Read(int id);
        public IQueryable<Renting> ReadAll();

    }

}
