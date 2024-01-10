using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ZealandMarketPlace.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Item> FavouriteItems { get; set; }
    }
}

