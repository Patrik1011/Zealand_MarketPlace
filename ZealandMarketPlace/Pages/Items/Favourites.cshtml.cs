using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    [Authorize]
    public class FavouritesModel : PageModel
    {
        private IItemService itemService;
        public IEnumerable<Item> Items { get; set; }
        public string ImagePath { get; set; }
        public FavouritesModel(IItemService iService)
        {
            itemService = iService;
        }

        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Items = itemService.GetFavouritesList(userId);
            
        }
    }
}
