using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:54726");


            rest.Post<Car>(new Car()
            {
                CarID = 1,
                CarName = "Lamborgini"
            }, "car");

            var carStore = rest.Get<CarStore>("car");
            var cars = rest.Get<Car>("car");
            var renting = rest.Get<Renting>("renting");


        }
    }
}
