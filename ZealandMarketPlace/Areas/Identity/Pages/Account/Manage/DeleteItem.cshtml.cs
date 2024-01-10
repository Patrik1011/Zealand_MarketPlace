using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Areas.Identity.Pages.Account.Manage
{
    public class DeleteItem : PageModel
    {
        
        private IItemService itemService;
    
        [BindProperty]
        public int ItemId { get; set; }
        
        public DeleteItem(IItemService iService)
        {
            itemService = iService;
        }
    
        public IActionResult OnGet(int itemId)
        {
            ItemId = itemId;
            return Page();
        }
    
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = itemService.GetItem(ItemId);
            if (item != null)
            {
                itemService.DeleteItem(item);
            }
            return RedirectToPage("./ManageItems");
        }
    }
}