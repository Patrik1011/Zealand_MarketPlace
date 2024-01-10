using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZealandMarketPlace.Models
{

    public class UserFavourite
    {

        [Key] public int FavouriteId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

    }
}