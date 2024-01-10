using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZealandMarketPlace.Services.Interfaces;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.EFServices
{
    public class EFItemService : IItemService
    {
        private MarketPlaceDbContext context;

        public EFItemService(MarketPlaceDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Item> GetAllUserItems(string userId)
        {
            return context.Items.Where(item => item.UserId == userId);
        }

        public IEnumerable<Item> GetAllItems(Category? category, string search)
        {
            switch (category)
            {
                case null when string.IsNullOrEmpty(search):
                    return context.Items;
                case null:
                    return context.Items.Where(i => i.Name.ToLower().Contains(search.ToLower()));
                default:
                {
                    return string.IsNullOrEmpty(search)
                        ? context.Items.Where(i => i.Category == category)
                        : context.Items.Where(
                            i => i.Category == category && i.Name.ToLower().Contains(search.ToLower()));
                }
            }
        }

        public Item GetItem(int itemId)
        {
            return context.Items.FirstOrDefault(i => i.ItemId == itemId);
        }

        public void UpdateItem(Item item)
        {
            context.Update(item);
            context.SaveChanges();
        }

        public void AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Item> FilterByPrice(double minPrice, double maxPrice)
        {
            return context.Items.Where(item => item.Price >= minPrice && item.Price <= maxPrice);
        }

        public void DeleteItem(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }
        public void DeleteItemById(int itemId)
        {
            context.Items.Remove(GetItem(itemId));
            context.SaveChanges();
        }


        public IEnumerable<Item> GetFavouritesList(string userId)
        {
            IEnumerable<UserFavourite> data = context.UserFavourites.Where(i => i.UserId == userId);
            var dataIds = data.Select(d => d.ItemId).ToList();
            return context.Items.Where(i => dataIds.Contains(i.ItemId));
        }
    }
}