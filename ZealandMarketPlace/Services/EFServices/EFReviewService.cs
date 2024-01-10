using System.Collections.Generic;
using System.Linq;
using ZealandMarketPlace.Models;
using ZealandMarketPlace.Services.Interfaces;

namespace ZealandMarketPlace.Services.EFServices
{

    public class EFReviewService : IReviewService
    {
        private MarketPlaceDbContext context;

        public EFReviewService(MarketPlaceDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Review> GetAllReview()
        {
            return context.Reviews;
        }

        public Review GetReviewById(int id)
        {
            return context.Reviews.Find(id);
        }

        public void CreateReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }


        public void UpdateReview(Review review)
        {
            context.Reviews.Update(review);
            context.SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        public IEnumerable<Review> ReviewsByReceiver(string receiverId)
        {
            return context.Reviews.Where(r => r.ReceiverId == receiverId);
        }

        public IEnumerable<Review> ReviewsByWriter(string writerId)
        {
            return context.Reviews.Where(r => r.WriterId == writerId);
        }

    }
}