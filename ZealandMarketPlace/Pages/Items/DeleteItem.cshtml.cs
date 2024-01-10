using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    [Authorize]
    public class DeleteItemModel : PageModel
    {
        private IItemService itemService;
        public Item item { get; set; }
        public DeleteItemModel(IItemService service)
        {
            itemService = service;
        }
        public void OnGet(int itemId)
        {
            item = itemService.GetItem(itemId);
        }
        public IActionResult OnPost(int itemId)
        {
            itemService.DeleteItemById(itemId);
            return RedirectToPage("/Index");
        }
    }
}
