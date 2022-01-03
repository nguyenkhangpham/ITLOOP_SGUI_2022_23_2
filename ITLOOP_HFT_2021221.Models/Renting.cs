using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Models
{
    [Table("Renting")]
    public class Renting
    {
        public int Id { get; set; }
        public int? CarId { get; set; }

        [MaxLength(30)]
        public string RenterName { get; set; }

        public int Amount { get; set; }
        public virtual Car Car { get; set; }

        public override string ToString()
        {
            string value = ($"Name:{RenterName} Id:{Id} in car:{CarId} Amount:{Amount}");
            return value;
        }

    }
}
