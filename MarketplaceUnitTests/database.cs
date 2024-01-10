using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZealandMarketPlace.Models;

namespace MarketplaceUnitTests
{

    [TestClass]
    public class UnitTest1
    {
        
        private  MarketPlaceDbContext context;

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<MarketPlaceDbContext> options;
            var builder = new DbContextOptionsBuilder<MarketPlaceDbContext>();
            builder.UseInMemoryDatabase("Azure");
            var dbOptions = builder.Options;
            context = new MarketPlaceDbContext(dbOptions);
        }
        
        
        [TestMethod]
        public void AddItemTest()
        {
            string testId = "abcd1234";
            var testItem = new Item
            {
                Name = "Dog",
                Descritpion = "Kind, nice",
                Category = Category.Kitchen,
                DateTime = DateTime.Now,
                Price = 22.3,
                Status = Status.Available,
                UserId = testId
                
            };
            context.Items.Add(testItem);
            context.SaveChanges();
            var items = context.Items.Select(i => i.UserId);
            
            Assert.IsTrue(items.Contains(testId));
            Assert.IsFalse(items.Contains("4321dcba"));
        }

        [TestMethod]
        public void AddReview()
        {
            var testReview = new Review
            {
                WriterId = "1",
                ReceiverId = "2",

            };
            context.Reviews.Add(testReview);
            context.SaveChanges();
            
            Assert.IsTrue(context.Reviews.Count() == 1);
        }


        [TestMethod]
        public void UpdateItem()
        {
            string testId = "abcd1234";
            string firstDescription = "Kind, nice";
            var testItem = new Item
            {
                Name = "Dog",
                Descritpion = firstDescription,
                Category = Category.Kitchen,
                DateTime = DateTime.Now,
                Price = 22.3,
                Status = Status.Available,
                UserId = testId
                
            };
            context.Items.Add(testItem);
            context.SaveChanges();
            var item = context.Items.FirstOrDefault(i => i.UserId == testId);
            Assert.IsTrue(item.Descritpion == firstDescription);

            string updatedDescription = "Mean, aggressive";
            item.Descritpion = updatedDescription;

            context.Items.Update(item);
            context.SaveChanges();
            
            var updatedItem = context.Items.FirstOrDefault(i => i.UserId == testId);
            
            Assert.IsTrue(updatedItem.Descritpion == updatedDescription);
            Assert.IsFalse(updatedItem.Descritpion == firstDescription);
            
        }

        [TestMethod]
        public void DeleteItem()
        {
            string testId = "abcd1234";
            var testItem = new Item
            {
                Name = "Dog",
                Descritpion = "Nice",
                Category = Category.Kitchen,
                DateTime = DateTime.Now,
                Price = 22.3,
                Status = Status.Available,
                UserId = testId
                
            };
            context.Items.Add(testItem);
            context.SaveChanges();
            var items = context.Items.Select(i => i.UserId);
            
            Assert.IsTrue(items.Contains(testId));
            context.Items.Remove(testItem);
            var updatedRows = context.SaveChanges();
            Assert.IsTrue(updatedRows == 1);


            


        }
        
        
    }
}