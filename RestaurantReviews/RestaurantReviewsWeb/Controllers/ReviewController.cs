﻿using System;
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

                return RedirectToAction("ListReviews/"+id);
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
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

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
