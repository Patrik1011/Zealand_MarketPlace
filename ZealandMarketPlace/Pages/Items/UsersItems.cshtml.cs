using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    [Authorize]
    public class UsersItems : PageModel
    {
        
        private IItemService _itemService;
        private IOrderService _orderService;
        public IEnumerable<Item> Items { get; set; }
        public string ImagePath { get; set; }
        public IdentityUser ItemUser { get; set; }

        public UsersItems(IItemService iService, IOrderService oService)
        {
            _itemService = iService;
            _orderService = oService;
        }
        
        
        public void OnGet(string userId)
        {
            Items = _itemService.GetAllUserItems(userId);
            ItemUser = _orderService.GetUser(userId);
        }
    }
}