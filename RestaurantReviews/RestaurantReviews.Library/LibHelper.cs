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
        private static RestaurantDBEntities db;
        static public IEnumerable<RestaurantReviewsLibrary.Restaurant> GetRestaurants()
        {
            IEnumerable<RestaurantReviewsLibrary.Restaurant> result;
            using (db = new RestaurantDBEntities())
            {
                var dataList = db.Restaurants.ToList();
                result = dataList.Select(x => DataToLibrary(x)).ToList();
            }
            return result;
        }

        static public void AddRestaurant(Restaurant item)
        {
            using (var db = new RestaurantDBEntities())
            {
                db.Restaurants.Add(LibraryToData(item));
                db.SaveChanges();
            }
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
            var libModel = new RestaurantReviewsLibrary.Restaurant()
            {
                RestaurantName = dataModel.restaurantName,
                RestaurantAddress = dataModel.restaurantAddress,
                RestaurantCity = dataModel.restaurantCity,
                RestaurantState = dataModel.restaurantState,
                RestaurantPhoneNumber = dataModel.restaurantPhoneNumber,
                RestaurantURL = dataModel.restaurantURL,
                CustomerRating = (float)dataModel.customerRating
                
            };
            return libModel;
        }

        public static RestaurantReviewsData.Restaurant LibraryToData(Restaurant libModel)
        {
            var dataModel = new RestaurantReviewsData.Restaurant()
            {
                restaurantName = libModel.RestaurantName,
                restaurantAddress = libModel.RestaurantAddress,
                restaurantCity = libModel.RestaurantCity,
                restaurantState = libModel.RestaurantState,
                restaurantPhoneNumber = libModel.RestaurantPhoneNumber,
                restaurantURL = libModel.RestaurantURL,
                Reviews = new List<RestaurantReviewsData.Review>()
            };
            List<RestaurantReviewsLibrary.Review> tempList = libModel.GetStoreReviews();
            foreach(RestaurantReviewsLibrary.Review r in tempList)
            {
                dataModel.Reviews.Add(ReviewOjectToData(r));
            }
            return dataModel;
        }
        public static RestaurantReviewsLibrary.Review ReviewDataToObject(RestaurantReviewsData.Review data)
        {
            var libModel = new RestaurantReviewsLibrary.Review()
            {
                RestaurantID = data.ID,
                ReviewerName = data.reviewerName,
                ReviewText = data.reviewText,
                ReviewScore = (float)data.reviewScore

            };
            return libModel;
        }

        public static RestaurantReviewsData.Review ReviewOjectToData(RestaurantReviewsLibrary.Review obj)
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

