using System.Collections.Generic;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.Interfaces
{

    public interface IFavouriteService
    {
        public IEnumerable<UserFavourite> GetUserFavourites(string userId);
        public IEnumerable<int> GetUserFavouritesItemsIds(string userId);
        public void ToggleUserFavouriteItem(string userId, int itemId);

    }
}