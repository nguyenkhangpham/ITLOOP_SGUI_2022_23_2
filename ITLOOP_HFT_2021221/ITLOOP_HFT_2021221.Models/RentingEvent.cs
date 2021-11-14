using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Models
{
    [Table("RentingEvent")]
    class RentingEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailble { get; set; }

        [NotMapped]
        public virtual ICollection<Brand> Brands { get; set; }

    }
}
