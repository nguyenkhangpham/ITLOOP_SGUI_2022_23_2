using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Endpoint.Controllers
{
    public class CarStoreController : Controller
    {
        ICarStoreLogic<CarStore> csl;

        public CarStoreController(ICarStoreLogic<CarStore> csl)
        {
            this.csl = csl;
        }

        [HttpGet]
        public IEnumerable<CarStore> GetAll()
        {
            return csl.ReadAll();
        }

        [HttpGet("{id}")]
        public CarStore Get(int id)
        {
            return csl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] CarStore value)
        {
            csl.Insert(value);
        }

        [HttpPut]
        public void Put([FromBody] CarStore value)
        {
            csl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            csl.Remove(id);
        }
        [HttpGet]
        public IEnumerable<int> GetCarStoreIdLessThan10()
        {
            return csl.GetCarStoreIdLessThan10();
        }
        [HttpGet]
        public IEnumerable<int> GEtCarStoreIdHigherThan20()
        {
            return csl.GEtCarStoreIdHigherThan20();
        }
        [HttpGet]
        public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100()
        {
            return csl.GetInforOfNewCarsHaveIdHigherThan100();
        }
        [HttpGet]
        public IEnumerable<string> GetCarNameDetail()
        {
            return csl.GetCarNameDetail();
        }
        [HttpGet]
        public IEnumerable<string> GetCategoryElectricCar()
        {
            return csl.GetCategoryElectricCar();
        }
    }
}
