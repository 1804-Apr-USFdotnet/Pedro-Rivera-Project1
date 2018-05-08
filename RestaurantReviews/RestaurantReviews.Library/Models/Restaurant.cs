using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get=> id; set => id = value; }
        [Required]
        [StringLength(25, ErrorMessage = "Restaurant Name should be within 25 characters")]
        public string RestaurantName { get => restaurantName; set => restaurantName = value; }
        [Required]
        public string RestaurantAddress { get => restaurantAddress; set => restaurantAddress = value; }
        [Required]
        public string RestaurantCity { get => restaurantCity; set => restaurantCity = value; }
        [Required]
        [StringLength(2, ErrorMessage = "Restaurant Name should be within 2 characters")]
        public string RestaurantState { get => restaurantState; set => restaurantState = value; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength =10, ErrorMessage="Phone Number should be between 10-15 characters")]
        [RegularExpression(@"^\+?(\d[\d -. ]+)?(\([\d -. ]+\))?[\d-. ]+\d$", ErrorMessage = "Invalid Phone Number.")]
        public string RestaurantPhoneNumber { get => restaurantPhoneNumber; set => restaurantPhoneNumber = value; }
        [Required]
        [DataType(DataType.Url)]
        public string RestaurantURL { get => restaurantURL; set => restaurantURL = value; }

        [NotMapped]
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
