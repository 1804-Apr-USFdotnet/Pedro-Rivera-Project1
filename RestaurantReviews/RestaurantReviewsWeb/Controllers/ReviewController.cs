using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviewsLibrary;

namespace RestaurantReviewsWeb.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        // GET: Review/ListReviews/5
        public ActionResult ListReviews(int id)
        {
            ViewBag.id = id;
            return View(LibHelper.ShowAllReviews(id));
        }

        // GET: Review/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Review temp = new Review
                    {
                        RestaurantID = id,
                        ReviewerName = collection["reviewerName"],
                        ReviewScore = (float)Convert.ToDouble(collection["reviewScore"]),
                        ReviewText = collection["reviewText"]
                    };

                    LibHelper.AddReview(temp);

                    return RedirectToAction("ListReviews/" + id);
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
            {
                return View("Model State is invalid.");
            }
            
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id, int id2)
        {
            ViewBag.id = id;
            return View(LibHelper.GetReviewFromRestaurant(id,id2));
        }
        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, int id2, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    Review temp = new Review
                    {
                        Id = id2,
                        RestaurantID = id,
                        ReviewerName = collection["reviewerName"],
                        ReviewText = collection["reviewText"],
                        ReviewScore = (float)Convert.ToDouble(collection["reviewScore"])
                    };

                    LibHelper.EditReview(temp);
                    return RedirectToAction("ListReviews/" + id);
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
            {
                return View("Model State is Invalid");
            }
            
        }
        // GET: Review/Delete/5
        public ActionResult Delete(int id, int id2)
        {
            ViewBag.id = id; 
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,int id2 ,FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                LibHelper.DeleteReviewFromDatabase(id2);
                return RedirectToAction("ListReviews/"+id);
            }
            catch
            {
                return View();
            }
        }
    }
}
