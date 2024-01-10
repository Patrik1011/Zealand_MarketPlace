using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Areas.Identity.Pages.Account.Manage;

public class ManageSubscription : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    public ManageSubscription(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    // Change the role of the user to Subscriber
    public RedirectResult OnPost()
    {
        var user = _userManager.GetUserAsync(User).Result;
        var role = _roleManager.FindByNameAsync("Subscriber").Result;
        var result = _userManager.AddToRoleAsync(user, role.Name).Result;
        _signInManager.RefreshSignInAsync(user).Wait();
        return result.Succeeded ? new RedirectResult("/") : new RedirectResult("/account/manage/ManageSubscription");
    }
}