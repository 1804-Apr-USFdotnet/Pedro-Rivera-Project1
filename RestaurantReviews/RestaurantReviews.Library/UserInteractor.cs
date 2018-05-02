using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsData;

namespace RestaurantReviewsLibrary
{
    public class UserInteractor
    {
        RestaurantCrud crud = new RestaurantCrud();
        SortLogic sort = new SortLogic();
        public int SelectOption()
        {
            int decision=0;
            while((decision < 1) || (decision > 6))
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Display 3 top rated restaurants");
                Console.WriteLine("2. Display all Restaurants");
                Console.WriteLine("3. Display Restaurant details");
                Console.WriteLine("4. Display all Reviews of Restaurant");
                Console.WriteLine("5. Search for Restaurant by name");
                Console.WriteLine("6. Quit");
                decision = int.Parse(Console.ReadLine());
                if ((decision < 1) || (decision > 6))
                    Console.WriteLine("Please choose a value between 1-6.");
            }
            return decision;
        }
        public bool OptionHandler()
        {
            int selection;
            ICollection<Restaurant> list;
            Console.WriteLine("");
            selection = SelectOption();
            List<Restaurant> convertedList = (List<RestaurantReviewsLibrary.Restaurant>)sort.convertList((List<RestaurantReviewsData.Restaurant>)crud.ListRestaurants());
            if(selection == 1)
            {
                list = sort.SortByRating(3,convertedList);
                foreach(Restaurant rest in list)
                {
                    Console.WriteLine(rest.RestaurantName + ": " + rest.CustomerRating);
                }
                return false;
            }
            if(selection == 2)
            {
                int sortDecision = 0;
                while(sortDecision!=1 && sortDecision != 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("To sort by name please enter 1.");
                    Console.WriteLine("To sort by rating please enter 2.");
                    sortDecision = int.Parse(Console.ReadLine());
                }
                if(sortDecision == 1)
                {
                    Console.WriteLine("");
                    list = sort.SortByNameAscending(convertedList);
                    foreach (Restaurant rest in list)
                    {
                        Console.WriteLine(rest.RestaurantName);
                    }
                    return false;
                }
                if(sortDecision == 2)
                {
                    list = sort.SortByRating(convertedList);
                    Console.WriteLine("");
                    foreach (Restaurant rest in list) 
                    {
                        Console.WriteLine(rest.RestaurantName + ": " + rest.CustomerRating);
                    }
                    return false;
                }
            }
            if(selection == 3)
            {
                Console.WriteLine("");
                int idDecision;
                Console.WriteLine("Enter a restaurant Id:");
                idDecision = int.Parse(Console.ReadLine());
                crud.ReadRestaurantDetails(idDecision);
                return false;
            }
            if (selection == 4)
            {
                Console.WriteLine("");
                ICollection<Review> revList;
                int idDecision;
                Console.WriteLine("Enter a restaurant Id:");
                idDecision = int.Parse(Console.ReadLine());
                revList = LibHelper.DataReviewListToLibraryReviewList(crud.GetReviewsById(idDecision));
                foreach(Review rev in revList)
                {
                    Console.WriteLine("Reivewer name: "+rev.ReviewerName+": "+rev.ReviewText+" Score: "+rev.ReviewScore);
                }
                return false;
            }
            if(selection == 5)
            {
                Console.WriteLine("");
                string searchQuery;
                Console.WriteLine("Search for: ");
                searchQuery = Console.ReadLine();
                list = sort.SearchRestaurantByName(searchQuery,convertedList);
                foreach(Restaurant res in list)
                {
                    Console.WriteLine(res.RestaurantName);
                }
                return false;
            }
            if (selection == 6)
                return true;
            return false;
        }
    }
}
