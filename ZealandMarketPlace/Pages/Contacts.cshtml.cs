using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages
{

    [Authorize]
    public class Contacts : PageModel
    {

        private IOrderService _iOrderService;

        public IEnumerable<IdentityUser> UsersContacts { get; set; }

        public Contacts(IOrderService service)
        {
            _iOrderService = service;
        }

        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UsersContacts = _iOrderService.GetBoughtUsers(userId);
        }
    }
}