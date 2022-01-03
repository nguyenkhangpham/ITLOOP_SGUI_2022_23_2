using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Models
{
    [Table("Car")]
    public class Car
    {
        public int Id { get; set; }
        public int? CarStoreID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CarName { get; set; }
        public int SellingPrice { get; set; }

        [NotMapped]
        public virtual CarStore CarStore { get; set; }
        public virtual List<Renting> Rentings { get; set; }
        public override string ToString()
        {
            string value = ($"Name:{CarName} Id: {Id} in CarStoreId:{CarStoreID} Price:{SellingPrice} ");
            return value;
        }
    }
}
