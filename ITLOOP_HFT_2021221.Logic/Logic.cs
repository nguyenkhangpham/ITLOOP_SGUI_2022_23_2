using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;
using ITLOOP_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;

namespace ITLOOP_HFT_2021221.Logic
{
    public abstract class Logic
    {
        CarStore carStore;
        Car car;
        Renting renting;
        protected Logic(CarStore carStore, Car car, Renting renting)
        {
            this.carStore = carStore;
            this.car = car;
            this.renting = renting;
        }
    }
}
