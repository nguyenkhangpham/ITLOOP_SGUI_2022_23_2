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
        [Key]
        public int CarID { get; set; }

        [MaxLength(50)]
        public string CarName { get; set; }

        [NotMapped]
        public virtual CarStore CarStore { get; set; }

        [ForeignKey(nameof(CarStore))]
        public int CarStoreID { get; set; }

        public virtual ICollection<Renting> Rentings { get; set; }

        public Car()
        {
            Rentings = new HashSet<Renting>();
        }
    }
}
