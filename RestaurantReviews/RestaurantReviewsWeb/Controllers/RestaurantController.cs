using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviewsLibrary;

namespace RestaurantReviewsWeb.Controllers
{
    public class RestaurantController : Controller
    {
        SortLogic sorter = new SortLogic();
        // GET: Restaurant
        public ActionResult Index(string SearchString,string sort)
        {
            List<Restaurant> allRestaurants = (List<Restaurant>)LibHelper.ShowAllRestaurants();
            ViewBag.SearchString = SearchString;
            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(sorter.SearchRestaurantByName(SearchString, allRestaurants ));
            }
            ViewBag.Top3 = sort == "Top3Rating" ? "sortTop3" : "Top3Rating";
            ViewBag.SortByRating = sort == "RatingsDescending" ? "ByRatings" : "RatingsDescending";
            ViewBag.SortByName = sort == "NamesAscending" ? "ByNames" : "NamesAscending";

            if(sort == "Top3Rating")
            {
                return View(sorter.SortByRating(3, allRestaurants));
            }
            if(sort == "RatingsDescending")
            {
                return View(sorter.SortByRating(allRestaurants));
            }
            if(sort == "NamesAscending")
            {
                return View(sorter.SortByNameAscending(allRestaurants));
            }
            else
                return View(LibHelper.ShowAllRestaurants());
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View(LibHelper.GetRestaurantById(id));
        }

        

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) //***TODO*** Need to finish the catch for this methdo
        {

            try
            {
                Restaurant temp = new Restaurant
                {
                    RestaurantName = collection["restaurantName"],
                    RestaurantAddress = collection["restaurantAddress"],
                    RestaurantCity = collection["restaurantCity"],
                    RestaurantState = collection["restaurantState"],
                    RestaurantPhoneNumber = collection["restaurantPhoneNumber"],
                    RestaurantURL = collection["restaurantURL"]

                };
                LibHelper.AddRestaurant(temp);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View(LibHelper.GetRestaurantById(id));
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Restaurant temp = new Restaurant
                {
                    Id = id,
                    RestaurantName = collection["restaurantName"],
                    RestaurantAddress = collection["restaurantAddress"],
                    RestaurantCity = collection["restaurantCity"],
                    RestaurantState = collection["restaurantState"],
                    RestaurantPhoneNumber = collection["restaurantPhoneNumber"],
                    RestaurantURL = collection["restaurantURL"]
                    
                };
                LibHelper.EditRestaurant(temp);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult DeleteRestaurant(int id)
        {
            return View(LibHelper.GetRestaurantById(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult DeleteRestaurant(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                LibHelper.DeleteFromDatabase(id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
