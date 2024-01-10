using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZealandMarketPlace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZealandMarketPlace.Models
{
    public class MarketPlaceDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MarketPlaceDbContext()
        {
        }

        public MarketPlaceDbContext(DbContextOptions<MarketPlaceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserFavourite> UserFavourites { get; set; }
    }
}