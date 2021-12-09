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
        ICarStoreLogic cl;

        public CarStoreController(ICarStoreLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<CarStore> GetAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public CarStore Get(int id)
        {
            return cl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] CarStore value)
        {
            cl.Insert(value);
        }

        [HttpPut]
        public void Put([FromBody] CarStore value)
        {
            cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Remove(id);
        }

        //
        //[HttpGet]
        //public IEnumerable<int> GetCarStoreIdLessThan10();
        //[HttpGet]
        //public IEnumerable<int> GEtCarStoreIdHigherThan20();
        //[HttpGet]
        //public IEnumerable<string> GetInforOfNewCarsHaveIdHigherThan100();
        //[HttpGet]
        //public IEnumerable<string> GetCarNameDetail();
        //[HttpGet]
        //public IEnumerable<string> GetCategoryElectricCar();
        //[HttpGet]
    }
}
