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
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarLogic<Car> cl;  

        public CarsController(ICarLogic<Car> cl)
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
            cl.InsertCar(value);
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
        
    }
}
