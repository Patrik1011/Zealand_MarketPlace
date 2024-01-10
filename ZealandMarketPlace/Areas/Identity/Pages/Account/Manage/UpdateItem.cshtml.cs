using System;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Areas.Identity.Pages.Account.Manage
{
    public class UpdateItem : PageModel
    {
        
    private IItemService itemService;
    
    [BindProperty]
    public Item Item { get; set; }
    
    public UpdateItem(IItemService iService)
    {
        itemService = iService;
    }
    
    public IActionResult OnGet(int itemId)
    {
        Item = itemService.GetItem(itemId);
        return Page();
    }
    
    [HttpPost]
    public IActionResult OnPost(int itemId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var files = Request.Form.Files; 
        if(files.Count == 1){
            MemoryStream ms = new MemoryStream();
            files[0].CopyTo(ms);
            Item.ImageData = ms.ToArray();
        
                ms.Close();
                ms.Dispose();
        }
    
        itemService.UpdateItem(Item);
        return RedirectToPage("./ManageItems");
    }
    }
}