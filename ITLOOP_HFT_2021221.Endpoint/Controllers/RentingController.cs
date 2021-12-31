using ITLOOP_HFT_2021221.Logic;
using ITLOOP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Endpoint.Controllers
{
    public class RentingController : Controller
    {
        IRentingLogic<Renting> rl;

        public RentingController(IRentingLogic<Renting> rl)
        {
            this.rl = rl;
        }

        [HttpGet]
        public IEnumerable<Renting> GetAll()
        {
            return rl.ReadAll();
        }

        [HttpGet("{id}")]
        public Renting Get(int id)
        {
            return rl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Renting value)
        {
            rl.Insert(value);
        }

        [HttpPut]
        public void Put([FromBody] Renting value)
        {
            rl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rl.Remove(id);
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
    }
}
