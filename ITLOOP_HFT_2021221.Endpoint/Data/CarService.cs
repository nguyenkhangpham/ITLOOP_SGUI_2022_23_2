using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Data;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Endpoint.Data
{
    public class CarService
    {
        private AppDbContext _context;
        public CarService (AppDbContext context)
        {
            _context = context;
        }
        //POST
        public void AddCar(Car car)
        {
            var _car = new Car()
            {
                CarID = car.CarID,
                CarName = car.CarName,
                CarStore = car.CarStore,
                CarStoreID = car.CarStoreID,
                Rentings = car.Rentings,

            };
            _context.Cars.Add(_car);
            _context.SaveChanges();
        }
        //GET
        public List<Car> GetAllCars()=> _context.Cars.ToList();
        public Car GetCarById(int carId) => _context.Cars.FirstOrDefault(n => n.CarID == carId);
        //PUT
        public Car UpdateCarById(int carId, Car car)
        {
            var _car = _context.Cars.FirstOrDefault(n => n.CarID == carId);
            if(_car != null)
            {
                _car.CarID = car.CarID;
                _car.CarName = car.CarName;
                _car.CarStore = car.CarStore;
                _car.CarStoreID = car.CarStoreID;
                _car.Rentings = car.Rentings;
                _context.SaveChanges();
            }
            return _car;
        }
        //DELETE
        public void DeleteCarById(int  carId)
        {
            var _car = _context.Cars.FirstOrDefault(n => n.CarID == carId);
            if (_car != null)
            {
                _context.Cars.Remove(_car);
                _context.SaveChanges();
            }
        }
    }

}
