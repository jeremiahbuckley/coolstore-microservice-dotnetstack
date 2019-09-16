using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReviewService.Models;

namespace ReviewService 
{
    public class ReviewSvc : IReviewSvc
    {
        private readonly ReviewContext context;

        public ReviewSvc(ReviewContext context) 
        {
            this.context = context;
        }

        public IList<Review> GetReviews(string itemId)
        {
            ReviewService.Models.Review r = context.Review
                .FirstOrDefault(c => c.ItemId == itemId);

            return new List<Review>() { r };
        }

    }

    public interface IReviewSvc 
    {
        IList<Review> GetReviews(string itemId);
    }
}