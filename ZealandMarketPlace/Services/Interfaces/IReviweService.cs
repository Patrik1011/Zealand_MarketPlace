using System.Collections.Generic;
using ZealandMarketPlace.Models;

namespace ZealandMarketPlace.Services.Interfaces
{

    public interface IReviewService
    {
        public IEnumerable<Review> GetAllReview();
        public Review GetReviewById(int id);
        public void CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(Review review);
        public IEnumerable<Review> ReviewsByReceiver(string receiverId);
        public IEnumerable<Review> ReviewsByWriter(string writerId);

    }
}