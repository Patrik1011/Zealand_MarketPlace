using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZealandMarketPlace.Models
{

    public enum Rating
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }

    public class Review
    {
        [Key] public int ReviewId { get; set; }

        [ForeignKey("ApplicationUser")] public string WriterId { get; set; }


        [ForeignKey("ApplicationUser")] public string ReceiverId { get; set; }

        [Required] public string ReviewText { get; set; }

        [Required] public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        // public virtual ApplicationUser ApplicationUser { get; set; }

    }

}