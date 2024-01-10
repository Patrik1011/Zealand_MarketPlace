using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZealandMarketPlace.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage ="An Item Name is required")]
        [StringLength(25, ErrorMessage ="Name is too long")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(200,ErrorMessage ="Description is too long")]
        public string Descritpion { get; set; }
        
        public byte[] ImageData { get; set; }
        
        [Required]
        [Range(0.01,100000.00, ErrorMessage ="Price must be between 0.01 and 100000.00")]
        public double Price { get; set; }
       
        public DateTime DateTime { get; set; }
        
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        
        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
