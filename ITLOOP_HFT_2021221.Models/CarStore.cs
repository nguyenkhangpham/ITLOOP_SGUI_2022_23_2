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
        [Key]
        public int CarStoreID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Infor { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [NotMapped]
        public string AllData => $"[{CarStoreID}] : {Infor} : {Category} (Items: {Cars.Count()})";

        public virtual ICollection<Car> Cars { get; set; }

        public CarStore()
        {
            Cars = new HashSet<Car>(); //cant create instance of interface, so we make a hashset
        }
    }
}
