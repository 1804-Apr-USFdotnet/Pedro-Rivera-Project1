using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsLibrary;
using RestaurantReviewsWeb.Controllers;

namespace RestaurantReviewsWeb_Tests.Tests.Controllers
{
    [TestClass]
    public class ReviewController_Tests
    {
        [TestMethod]
        public void ReviewModelNameTest()
        {
            ReviewController controller = new ReviewController();

            var detailCheck = controller.Edit(3,6) as ViewResult;
            var actual = detailCheck.Model as Review;

            Assert.AreEqual("Pedro", actual.ReviewerName);
        }
        [TestMethod]
        public void BadReviewIsNullTest()
        {
            ReviewController controller = new ReviewController();

            var check = controller.Edit(3, 1) as ViewResult;
            var actual = check.Model as Review;

            Assert.IsNull(actual);
        }
        [TestMethod]
        public void GoodReviewIsNotNullTest()
        {
            ReviewController controller = new ReviewController();

            var detailCheck = controller.Edit(3, 6) as ViewResult;
            var actual = detailCheck.Model as Review;

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ReviewModelTextTest()
        {
            ReviewController controller = new ReviewController();

            var detailCheck = controller.Edit(3, 8) as ViewResult;
            var actual = detailCheck.Model as Review;

            Assert.AreEqual("Its fine", actual.ReviewText);
        }
        [TestMethod]
        public void ReviewModelScoreTest()
        {
            ReviewController controller = new ReviewController();

            var detailCheck = controller.Edit(3, 6) as ViewResult;
            var actual = detailCheck.Model as Review;

            Assert.AreEqual(3, actual.ReviewScore);
        }
    }
}
