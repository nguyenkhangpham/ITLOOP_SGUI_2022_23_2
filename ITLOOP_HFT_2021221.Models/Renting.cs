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
        [Key]
        public int RentID { get; set; }

        [MaxLength(30)]
        public string RenterName { get; set; }

        public int Amount { get; set; }

        [NotMapped]
        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarID { get; set; }

    }
}
