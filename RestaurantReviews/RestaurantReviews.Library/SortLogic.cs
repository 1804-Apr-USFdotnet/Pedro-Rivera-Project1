using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsData;

namespace RestaurantReviewsLibrary
{
    public class SortLogic
    {
        RestaurantCrud crud = new RestaurantCrud();
        
        public ICollection<Restaurant> SortByRating(int listAmount, List<Restaurant> tempList)
        {
            return tempList.OrderByDescending(rating => rating.CustomerRating).Take(listAmount).ToList();
        }
        public ICollection<Restaurant> convertList(List<RestaurantReviewsData.Restaurant> tempList)
        {
            List<Restaurant> result = (List<Restaurant>)LibHelper.DataListToLibraryList(tempList);
            return result;
        }
        public ICollection<Restaurant> SortByRating(List<Restaurant> tempList)
        {
            return tempList.OrderByDescending(rating => rating.CustomerRating).ToList();
        }
        public ICollection<Restaurant> SortByNameAscending(List<Restaurant> tempList)
        {
            return tempList.OrderBy(name =>name.RestaurantName).ToList();
        }
        public ICollection<Restaurant> SearchRestaurantByName(string str, List<Restaurant> tempList)
        {
            return tempList.FindAll(name => name.RestaurantName.ToUpper().Contains(str.ToUpper())).ToList();
        }
    }
}
