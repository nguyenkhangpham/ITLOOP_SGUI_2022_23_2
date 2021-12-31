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
        //T GetOne(int id); //read
        //IEnumerable<T> GetAll();
        //void Insert(T entity); //create
        //void Remove(int id); // delete
        //public void Create();
        //public void Read();
        //public void Update();
        //public void Delete();
    }
    //public interface ICarStoreLogic : ILogic<CarStore>
    //{
    //    //public void ChangeInfor(int id, string newInfor);
    //    //public void ChangeCategory(int id, string newCategory);
    //    public void Insert(CarStore carStore);
    //    public void Remove(int id);
    //    public CarStore Read(int id);
    //    public void Update(CarStore carStore);
    //    public IQueryable<CarStore> ReadAll();
    //    //non crud
    //    public IEnumerable<int> GetCarStoreIdLessThan10();
    //    public IEnumerable<int> GEtCarStoreIdHigherThan20();
    //    public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100();
    //    public IEnumerable<string> GetCarNameDetail();
    //    public IEnumerable<string> GetCategoryElectricCar();

    //}
    //public interface ICarLogic : ILogic<Car>
    //{
    //    //public int DiscountPrice();
    //    //public IEnumerable<KeyValuePair<string, int>> DiscountPriceInCarStore();
    //    //public void ChangeInfor(int id, string newInfor);
    //    public void Insert(Car car);
    //    public void Remove(int id);
    //    public Car Read(int id);
    //    public void Update(Car car);
    //    public IQueryable<Car> ReadAll();

    //    //non crud
    //    public IEnumerable<int> GetHighLevelCar();
    //    public IEnumerable<int> GetNormalLevelCar();
    //    public IEnumerable<int> GetLowLevelCar();
    //    public IEnumerable<string> GetCategoryInCarStore();
    //    public IEnumerable<int> GetAmountOfRenting();




    //}
    //public interface IRentingLogic : ILogic<Renting>
    //{
    //    public void Insert(Renting car);
    //    public void Remove(int id);
    //    public Renting Read(int id);
    //    public void Update(Renting car);
    //    public IQueryable<Renting> ReadAll();
    //    //non crud
    //    public IEnumerable<int> GetRentAmountLessThan10000();
    //    public IEnumerable<int> GetRentAmountHigherThan20000();
    //    public IEnumerable<int> GetCarIdHasAmountLessThan10000();
    //    public IEnumerable<int> GetCarIdHasAmountHigherThan20000();
    //    public IEnumerable<string> GetCarNameHasAmountHigherThan10000();

    //}

}
