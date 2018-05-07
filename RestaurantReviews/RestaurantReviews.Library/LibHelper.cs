using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsData;
using System.Data;

namespace RestaurantReviewsLibrary
{
    public static class LibHelper
    {
        private static RestaurantCrud crud = new RestaurantCrud();

        public static void DeleteFromDatabase(int id)
        {
            crud.DeleteRestaurant(id);
        }

        public static void AddRestaurant(Restaurant restaurant)
        {
            var temp = LibraryToData(restaurant);
            crud.InsertRestaurant(temp);
        } 

        public static void AddReview(Review review)
        {
            var temp = ReviewObjectToData(review);
            crud.InsertReview(temp);
        }

        public static void EditRestaurant(Restaurant restaurant)
        {
            var newRest = LibraryToData(restaurant);
            crud.UpdateRestaurant(newRest);
        }

        static public ICollection<Restaurant> ShowAllRestaurants()
        {
            return DataListToLibraryList(crud.ListRestaurants());
        }

        public static ICollection<Review> ShowAllReviews(int id)
        {
            return DataReviewListToLibraryReviewList(crud.GetReviewsById(id));
        }

        static public Restaurant GetRestaurantById(int id)
        {
            return DataToLibrary(crud.getRestaurantById(id));
        }
        // mapping
        
        public static ICollection<Restaurant> DataListToLibraryList(ICollection<RestaurantReviewsData.Restaurant> dataList)
        {
            ICollection<Restaurant> restaurants = new List<Restaurant>();
            foreach (RestaurantReviewsData.Restaurant r in dataList)
                restaurants.Add(DataToLibrary(r));
            return restaurants;
        } 

        public static ICollection<Review> DataReviewListToLibraryReviewList(ICollection<RestaurantReviewsData.Review> dataList)
        {
            ICollection<Review> reviews = new List<Review>();
            foreach (RestaurantReviewsData.Review r in dataList)
                reviews.Add(ReviewDataToObject(r));
            return reviews;
        }

        public static RestaurantReviewsLibrary.Restaurant DataToLibrary(RestaurantReviewsData.Restaurant dataModel)
        {
            var reviews = ShowAllReviews(dataModel.ID);
            


            var libModel = new RestaurantReviewsLibrary.Restaurant()
            {
                RestaurantName = dataModel.restaurantName,
                RestaurantAddress = dataModel.restaurantAddress,
                RestaurantCity = dataModel.restaurantCity,
                RestaurantState = dataModel.restaurantState,
                RestaurantPhoneNumber = dataModel.restaurantPhoneNumber,
                RestaurantURL = dataModel.restaurantURL,
                //CustomerRating = (float)dataModel.customerRating,
                

                StoreReviews = (List<Review>)reviews,
                Id = dataModel.ID
                
            };
            libModel.UpdateRating();    
            return libModel;
        }

        public static RestaurantReviewsData.Restaurant LibraryToData(Restaurant libModel)
        {
            var dataModel = new RestaurantReviewsData.Restaurant()
            {
                ID = libModel.Id,
                restaurantName = libModel.RestaurantName,
                restaurantAddress = libModel.RestaurantAddress,
                restaurantCity = libModel.RestaurantCity,
                restaurantState = libModel.RestaurantState,
                restaurantPhoneNumber = libModel.RestaurantPhoneNumber,
                restaurantURL = libModel.RestaurantURL,
                Reviews = new List<RestaurantReviewsData.Review>()
            };
            List<RestaurantReviewsLibrary.Review> tempList = libModel.GetStoreReviews();
            foreach (RestaurantReviewsLibrary.Review r in tempList)
            {
                dataModel.Reviews.Add(ReviewObjectToData(r));
            }
            return dataModel;
        }
        public static RestaurantReviewsLibrary.Review ReviewDataToObject(RestaurantReviewsData.Review data)
        {
            var libModel = new RestaurantReviewsLibrary.Review()
            {
                RestaurantID = data.restaurantID,
                ReviewerName = data.reviewerName,
                ReviewText = data.reviewText,
                ReviewScore = (float)data.reviewScore,
                Id = data.ID
            };
            return libModel;
        }

        public static RestaurantReviewsData.Review ReviewObjectToData(RestaurantReviewsLibrary.Review obj)
        {
            var dataModel = new RestaurantReviewsData.Review()
            {
                restaurantID = obj.RestaurantID,
                reviewerName = obj.ReviewerName,
                reviewText = obj.ReviewText,
                reviewScore = obj.ReviewScore
            };
            return dataModel;
        }
    }
}

