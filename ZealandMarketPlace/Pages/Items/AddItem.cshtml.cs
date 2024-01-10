using System;
using System.Collections.Generic;
using System.IO;
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
    public class AddItemModel : PageModel
    {
        private IItemService itemService;
        
        [BindProperty]
        public Item Item { get; set; }

        public AddItemModel(IItemService iService)
        {
            itemService = iService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        
        [HttpPost]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            foreach(var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Item.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            Item.DateTime = DateTime.Now;
            Item.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            itemService.AddItem(Item);
            return RedirectToPage("../Index");
        }
    }
}
