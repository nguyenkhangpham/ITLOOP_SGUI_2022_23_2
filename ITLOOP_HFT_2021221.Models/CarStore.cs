using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Models
{
    [Table("CarStore")]
    public class CarStore
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Infor { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [NotMapped]
        public virtual List<Car> Cars { get; set; }
        public override string ToString()
        {
            string value = ($"Name:{Name} Id:{Id} Infor:{Infor} Category:{Category}");
            return value;
        }
    }
}
