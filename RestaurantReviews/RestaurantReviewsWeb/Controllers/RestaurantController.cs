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
        
        // GET: Restaurant
        public ActionResult Index()
        {

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
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
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
            catch
            {
                return View();
            }
        }
    }
}
