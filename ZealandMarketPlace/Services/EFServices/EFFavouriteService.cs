using System.Collections.Generic;
using System.Linq;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Services.EFServices
{

    public class EFFavouriteService : IFavouriteService
    {
        private MarketPlaceDbContext context;
        public EFFavouriteService(MarketPlaceDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<UserFavourite> GetUserFavourites(string userId)
        {
            return context.UserFavourites.Where(f => f.UserId == userId);
        }

        public IEnumerable<int> GetUserFavouritesItemsIds(string userId)
        {
            return GetUserFavourites(userId).Select(i => i.ItemId);
        }

        public void ToggleUserFavouriteItem(string userId, int itemId)
        {
            var usersFavourites = GetUserFavourites(userId);
            var usersFavouriteIds = usersFavourites.Select(u => u.ItemId);
            if (usersFavouriteIds.Contains(itemId))
            {
                context.UserFavourites.Remove(usersFavourites.FirstOrDefault(i => i.ItemId == itemId));
            }
            else
            {
                var newUserFavourite = new UserFavourite
                {
                    ItemId = itemId,
                    UserId = userId
                };
                context.UserFavourites.Add(newUserFavourite);
            }

            context.SaveChanges();
        }

    }
}