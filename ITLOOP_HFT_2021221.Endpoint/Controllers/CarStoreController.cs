using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarStoreController : ControllerBase
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
        
    }
}
