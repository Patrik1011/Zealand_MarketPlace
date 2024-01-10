using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Areas.Identity.Pages.Account.Manage
{
    public class ManageItems : PageModel
    {
        private IItemService _itemService;
        private readonly UserManager<IdentityUser> _userManager;
        public IEnumerable<Item> Items { get; set; }
       
        public ManageItems(IItemService service,UserManager<IdentityUser> userManager)
        {
            _itemService = service;
            _userManager = userManager;
        }
        
        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);
            Items = _itemService.GetAllUserItems(userId);
        }
    }
}