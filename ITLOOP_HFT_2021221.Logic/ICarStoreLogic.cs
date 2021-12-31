using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Logic
{
    public interface ICarStoreLogic<T> where T : class
    {
        //public void ChangeInfor(int id, string newInfor);
        //public void ChangeCategory(int id, string newCategory);
        public void Insert(T carStore);
        public void Remove(int id);
        public T Read(int id);
        public void Update(T carStore);
        public IQueryable<T> ReadAll();
        //non crud
        public IEnumerable<int> GetCarStoreIdLessThan10();
        public IEnumerable<int> GEtCarStoreIdHigherThan20();
        public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100();
        public IEnumerable<string> GetCarNameDetail();
        public IEnumerable<string> GetCategoryElectricCar();

    }
}
