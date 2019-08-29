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

        public IList<Review> getReviews(string itemId)
        {
            ReviewService.Models.Review r = context.Review
                .FirstOrDefault(c => c.ItemId == itemId)
                // .FirstOrDefault(c => c.ItemId == itemId)
                // .ToList()
                ;

            return new List<Review>() { r };

            // Review r = new Review();
            // r.ItemId = "11A";
            // r.ReviewId = 27;
            // r.Content = "Test";
            // r.Username = "John";
            // r.Title = "This is only a ";
            // r.CreateDate = DateTime.Now;
            // return new List<Review>(){r};

        }

    }

    public interface IReviewSvc 
    {
        IList<Review> getReviews(string itemId);
    }
}