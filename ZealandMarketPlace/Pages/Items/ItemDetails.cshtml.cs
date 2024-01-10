using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Pages.Items
{
    public class ItemDetailsModel : PageModel
    {
        private IItemService _itemService;
        private IOrderService _orderService;
        private IReviewService _reviewService;
        private IFavouriteService _favouriteService;
        private UserManager<IdentityUser> _userManager;
        public Item Item { get; set; }
        [BindProperty] public int ItemId { get; set; }
        public List<string> BoughtContacts { get; set; }
        public List<int> FavouriteItems { get; set; }

        [BindProperty] public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }

        [BindProperty] public Review Review { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public ItemDetailsModel(IItemService service, IOrderService orderService, IReviewService reviewService,
            IFavouriteService favouriteService, UserManager<IdentityUser> userManager)
        {
            _itemService = service;
            _orderService = orderService;
            _reviewService = reviewService;
            _favouriteService = favouriteService;
            _userManager = userManager;
        }

        public void OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
            {
                RedirectToPage("/NotFound");
                return;
            }

            Reviews = _reviewService.ReviewsByReceiver(Item.UserId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            BoughtContacts = new List<string>();
            FavouriteItems = new List<int>();
            if (string.IsNullOrEmpty(userId)) return;
            var usersOrders = _orderService.GetUserOrders(userId);
            var userFavourites = _favouriteService.GetUserFavourites(userId);
            Owner = _userManager.FindByIdAsync(Item.UserId).Result;

            foreach (var order in usersOrders)
            {
                BoughtContacts.Add(order.ContactUser);
            }

            foreach (var favourite in userFavourites)
            {
                FavouriteItems.Add(favourite.ItemId);
            }
        }

        public RedirectResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return new RedirectResult("/Identity/Account/Login");
            }

            var order = new Order
            {
                UserId = userId,
                ContactUser = OwnerId
            };
            _orderService.AddOrder(order);
            return new RedirectResult("/Contacts");
        }

        public void OnPostReview()
        {
            Review.WriterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _reviewService.CreateReview(Review);
            OnGet(ItemId);
        }


        public RedirectResult OnPostFavourite()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return new RedirectResult("/Identity/Account/Login");
            }

            _favouriteService.ToggleUserFavouriteItem(userId, ItemId);
            return new RedirectResult("/Items/Favourites");
        }
    }
}