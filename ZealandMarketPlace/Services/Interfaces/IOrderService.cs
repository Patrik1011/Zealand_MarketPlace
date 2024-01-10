using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.Interfaces
{


    public interface IOrderService
    {
        public IEnumerable<Order> AllOrders();
        public Order GetOrder(int id);
        public void AddOrder(Order order);
        public void DeleteOrder(int id);
        public IEnumerable<Order> GetUserOrders(string userId);
        public IEnumerable<Order> GetReceivedOrders(string userId);

        public IEnumerable<IdentityUser> GetBoughtUsers(string userId);
        public IdentityUser GetUser(string userId);

    }
}