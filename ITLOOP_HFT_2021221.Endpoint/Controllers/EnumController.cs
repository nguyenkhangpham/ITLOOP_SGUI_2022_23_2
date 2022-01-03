using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        ICarLogic<Car> cl;
        ICarStoreLogic<CarStore> csl;
        IRentingLogic<Renting> rl;

        public EnumController (ICarLogic<Car> carLogic, ICarStoreLogic<CarStore> carStoreLogic, IRentingLogic<Renting> rentingLogic)
        {
            cl = carLogic;
            csl = carStoreLogic;
            rl = rentingLogic;
        }
        [HttpGet]
        public IEnumerable<int> GetHighLevelCar()
        {
            return cl.GetHighLevelCar();
        }
        [HttpGet]
        public IEnumerable<int> GetNormalLevelCar()
        {
            return cl.GetNormalLevelCar();
        }
        [HttpGet]
        public IEnumerable<int> GetLowLevelCar()
        {
            return cl.GetLowLevelCar();
        }
        [HttpGet]
        public IEnumerable<string> GetCategoryInCarStore()
        { 
            return cl.GetCategoryInCarStore();
        }
        [HttpGet]
        public IEnumerable<int> GetAmountOfRenting()
        {
            return cl.GetAmountOfRenting();
        }
        [HttpGet("{name}")]
        public IEnumerable<Car> CarWithSpecifyName(string name)
        {
            return cl.CarWithSpecifyName(name);
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

        [HttpGet]
        public IEnumerable<int> GetRentAmountLessThan10000()
        {
            return rl.GetRentAmountLessThan10000();
        }
        [HttpGet]
        public IEnumerable<int> GetRentAmountHigherThan20000()
        {
            return rl.GetRentAmountHigherThan20000();
        }
        [HttpGet]
        public IEnumerable<int> GetCarIdHasAmountLessThan10000()
        {
            return rl.GetCarIdHasAmountLessThan10000();
        }
        [HttpGet]
        public IEnumerable<int> GetCarIdHasAmountHigherThan20000()
        {
            return rl.GetCarIdHasAmountHigherThan20000();
        }
        [HttpGet]
        public IEnumerable<string> GetCarNameHasAmountHigherThan10000()
        {
            return rl.GetCarNameHasAmountHigherThan10000();
        }
        [HttpGet("{amount}")]
        public Renting HighestAmount()
        {
            return rl.HighestAmount() ;
        }
    }
}
