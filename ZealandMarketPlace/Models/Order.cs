using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZealandMarketPlace.Models
{

    public class Order
    {
        [Key] public int OrderId { get; set; }

        [ForeignKey("ApplicationUser")] public string UserId { get; set; }

        [ForeignKey("ApplicationUser")] public string ContactUser { get; set; }

        // [ForeignKey("UserId, UserId")]
        // public virtual ApplicationUser ApplicationUser { get; set; }

    }
}