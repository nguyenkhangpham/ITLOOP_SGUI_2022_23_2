using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Logic
{
    public interface IRentingLogic<T> where T : class
    {
        public void Insert(T car);
        public void Remove(int id);
        public T Read(int id);
        public void Update(T car);
        public IQueryable<T> ReadAll();
        //non crud
        public IEnumerable<int> GetRentAmountLessThan10000();
        public IEnumerable<int> GetRentAmountHigherThan20000();
        public IEnumerable<int> GetCarIdHasAmountLessThan10000();
        public IEnumerable<int> GetCarIdHasAmountHigherThan20000();
        public IEnumerable<string> GetCarNameHasAmountHigherThan10000();
    }
}
