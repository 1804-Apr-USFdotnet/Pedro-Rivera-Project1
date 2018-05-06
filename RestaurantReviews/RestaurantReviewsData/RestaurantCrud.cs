using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;


namespace RestaurantReviewsData
{
    public class RestaurantCrud
    {
        RestaurantDBEntities db = new RestaurantDBEntities();
        public enum ColumnChoice { restaurantName, restaurantAddress, restaurantCity, restaurantState, restaurantPhoneNumber, restaurantURL, customerRating };

        //Create
        public void InsertRestaurant(string _restaurantName, string _restaurantAddress, string _restaurantCity, string _restaurantState, string _restaurantPhoneNumber, string _restaurantURL)
        {
            Restaurant newRest = new Restaurant();
            newRest.restaurantName = _restaurantName;
            newRest.restaurantAddress = _restaurantAddress;
            newRest.restaurantCity = _restaurantCity;
            newRest.restaurantState = _restaurantState;
            newRest.restaurantPhoneNumber = _restaurantPhoneNumber;
            newRest.restaurantURL = _restaurantURL;
            newRest.customerRating = null;

            db.Restaurants.Add(newRest);
            db.SaveChanges();
        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }
        //Read Supplement
        public ICollection<Restaurant> ListRestaurants()
        {
            return db.Restaurants.ToList();
            
        }
        public ICollection<Review> GetReviewsById(int IdNum)
        {
            return db.Reviews.Where(rev => rev.restaurantID == IdNum).ToList();
        }
        
        //Read 
        public void ReadRestaurantDetails(int IdNum)
        {
            Restaurant rest = getRestaurantById(IdNum);
            Console.WriteLine(rest.ID + "|| " + rest.restaurantName + "|| " + rest.restaurantAddress + "|| " + rest.restaurantCity + ", " + rest.restaurantState + "|| " + rest.restaurantPhoneNumber + "|| " + rest.restaurantURL + "|| Rating: " + rest.customerRating);
        }


        //Search Restaurant by id (Update Supplement)
        public Restaurant getRestaurantById(int idNumber)
        {
            var temp = db.Restaurants.Find(idNumber);
            return temp;
        }


        //Update
        public void UpdateRestaurant(int id, ColumnChoice choiceName, string replacement)
        {
            int choice = (int)choiceName;
            Restaurant rest = getRestaurantById(id);
            if (choice.Equals(0))
            {
                rest.restaurantName = replacement;
            }
            if (choice.Equals(1))
            {
                rest.restaurantAddress = replacement;
            }
            if (choice.Equals(2))
            {
                rest.restaurantCity = replacement;
            }
            if (choice.Equals(3))
            {
                rest.restaurantState = replacement;
            }
            if (choice.Equals(4))
            {
                rest.restaurantPhoneNumber = replacement;
            }
            if (choice.Equals(5))
            {
                rest.restaurantURL = replacement;
            }
            if (choice.Equals(6))
            {
                rest.customerRating = float.Parse(replacement);
            }
            db.SaveChanges();
        }
        //Cannot get this to work, wasted too much time on it  
        //public void UpdateRestaurantReviews(Restaurant rest)
        //{
        //    Restaurant oldVersion = getRestaurantById(rest.ID);
        //    Review oldReview, newReview;
        //   // updatedRest = rest;
        //   //try instead looping thru updatedRest.REviews and applying values from rest.Reviews
        //   for(int i = 0; i < oldVersion.Reviews.Count; i++)
        //    {
        //        oldReview = oldVersion.Reviews.ElementAt(i);
        //        newReview = rest.Reviews.Where(x => x.ID == oldReview.ID).FirstOrDefault();
        //        if (newReview != null)
        //        {
        //            oldReview.reviewerName = newReview.reviewerName;
        //            oldReview.reviewText = newReview.reviewText;
        //            oldReview.reviewScore = newReview.reviewScore;
        //        }
        //        else
        //        {
        //            oldVersion.Reviews.Remove(oldReview);
        //            i--;
        //        }
        //    }
        //   foreach(var r in rest.Reviews)
        //    {
        //        oldReview = oldVersion.Reviews.Where(x => x.ID == r.ID).FirstOrDefault();
        //        if(oldReview == null)
        //        {
        //            oldVersion.Reviews.Add(r);
        //        }
        //    }
        //    db.SaveChanges();
        //}
        //Delete
        public void DeleteRestaurant(int id)
        {
            Restaurant rest = getRestaurantById(id);
            db.Restaurants.Remove(rest);
            db.SaveChanges();
        }
    }
}
