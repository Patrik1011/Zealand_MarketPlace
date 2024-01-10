using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.Interfaces
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems(Category? category, string search);
        Item GetItem(int itemId);
        void AddItem(Item item);
        IEnumerable<Item> FilterByPrice(double minPrice, double maxPrice);
        
        IEnumerable<Item> GetAllUserItems(string userId);
        void DeleteItem(Item item);
        void DeleteItemById(int itemId);
        void UpdateItem(Item item);

        public IEnumerable<Item> GetFavouritesList(string userId);
    }
}
