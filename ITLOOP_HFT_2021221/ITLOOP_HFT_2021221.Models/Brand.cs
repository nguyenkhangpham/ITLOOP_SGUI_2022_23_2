using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Models
{
    [Table("Brand")]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Amount { get; set; }
        public int CarId { get; set; }

        [ForeignKey("ReceiptId ")]

        [NotMapped]
        public virtual Car Car { get; set; }


    }
}
