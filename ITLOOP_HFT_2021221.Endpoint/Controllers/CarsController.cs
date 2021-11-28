using ITLOOP_HFT_2021221.Endpoint.Data;
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
        public CarService _carService;
        public CarsController(CarService carService)
        {
            _carService = carService;
        }
        [HttpPost("add-car")]
        public IActionResult AddCar ([FromBody] Car car)
        {
            _carService.AddCar(car);
            return Ok();
        }
        [HttpGet("get-all-cars")]
        public IActionResult GetAllCars()
        {
            var allCars = _carService.GetAllCars();
            return Ok();
        }
        [HttpGet("get-car_by-id/{CarID}")]
        public IActionResult GetCarById(int CarID)
        {
            var car = _carService.GetCarById(CarID);
            return Ok();
        }
        [HttpPut("update-car-by-id/{CarID}")]
        public IActionResult UpdateCarById(int id, [FromBody]Car car)
        {
            var updateCar = _carService.UpdateCarById(id, car);
            return Ok(updateCar);
        }
        [HttpDelete("delete-car-by-id")]
        public IActionResult DeleteCarById(int id)
        {
            _carService.DeleteCarById(id);
            return Ok();
        }
    }
}
