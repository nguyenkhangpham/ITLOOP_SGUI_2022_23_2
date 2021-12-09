using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarLogic cl;

        public CarsController(ICarLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Car Get(int id)
    {
        return cl.Read(id);
    }

        [HttpPost]
        public void Post([FromBody] Car value)
        {
            cl.Insert(value);
        }

        [HttpPut]
        public void Put([FromBody] Car value)
        {
            cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Remove(id);
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
    }
}
