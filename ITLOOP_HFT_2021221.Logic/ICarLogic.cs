using ITLOOP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Logic
{
    public interface ICarLogic<T> where T : class
    {
        public void InsertCar(T car);
        public void Remove(int id);
        public T Read(int id);
        public void Update(T car);
        public IEnumerable<T> ReadAll();
        //non crud
        public IEnumerable<int> GetHighLevelCar();
        public IEnumerable<int> GetNormalLevelCar();
        public IEnumerable<int> GetLowLevelCar();
        public IEnumerable<string> GetCategoryInCarStore();
        public IEnumerable<int> GetAmountOfRenting();
        public IEnumerable<T> CarWithSpecifyName(string name);

    }
}
