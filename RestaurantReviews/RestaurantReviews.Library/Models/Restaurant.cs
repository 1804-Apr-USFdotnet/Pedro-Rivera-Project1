using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviewsLibrary
{
    public class Restaurant
    {
        
        private int id;
        private string restaurantName; //This is where restaurant name is stored
        private string restaurantAddress;
        private string restaurantCity;
        private string restaurantState;
        private float customerRating;
        private string restaurantPhoneNumber;
        private string restaurantURL;

        private List<Review> storeReviews = new List<Review>();
        
           
        public int Id { get=> id; set => id = value; }
        public string RestaurantName { get => restaurantName; set => restaurantName = value; } //Will get or set restaurant name for you
        public string RestaurantAddress { get => restaurantAddress; set => restaurantAddress = value; }
        public string RestaurantCity { get => restaurantCity; set => restaurantCity = value; }
        public string RestaurantState { get => restaurantState; set => restaurantState = value; }
        public string RestaurantPhoneNumber { get => restaurantPhoneNumber; set => restaurantPhoneNumber = value; }
        public string RestaurantURL { get => restaurantURL; set => restaurantURL = value; }
        public float CustomerRating { get => customerRating; set => customerRating = value; }
        public List<Review> StoreReviews { get => storeReviews; set => storeReviews = value; }

        public override bool Equals(object obj)
        {
            Restaurant testRest = (Restaurant)obj;
            if (!testRest.restaurantName.Equals(this.restaurantName)){
                return false;
            }
            if (!testRest.restaurantAddress.Equals(this.restaurantAddress))
            {
                return false;
            }
            if (!testRest.restaurantCity.Equals(this.restaurantCity))
            {
                return false;
            }
            if (!testRest.restaurantState.Equals(this.restaurantState))
            {
                return false;
            }
            if (!testRest.restaurantPhoneNumber.Equals(this.restaurantPhoneNumber))
            {
                return false;
            }
            if (!testRest.restaurantURL.Equals(this.restaurantURL))
            {
                return false;
            }
            return true;
        }
        public void UpdateRating()
        {
            customerRating = CalculateRating();
        }
        private float CalculateRating()
        {
            int numOfReviews = 0;
            float scoreSum = 0.0f;
            if(storeReviews.Any())
            {
                foreach (Review item in storeReviews)
                {
                    scoreSum += item.GetReviewScore();
                    numOfReviews++;
                }
                return scoreSum / numOfReviews;
            }
            else
            {
                return 0;
            }
            
        }

        public List<Review> GetStoreReviews()
        {
            return storeReviews;
        } 

        public Review CreateReview()
        {
            Review newReview = new Review();
            newReview.UpdateName("Test Review");
            newReview.UpdateScore(5.0f);
            newReview.RestaurantID = 1;
            return newReview; 
        }
        public void AddReview(Review indx)
        {
            storeReviews.Add(indx);
        }     
    }
}
