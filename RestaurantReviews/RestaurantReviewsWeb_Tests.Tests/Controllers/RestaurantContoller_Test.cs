using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsWeb;
using RestaurantReviewsWeb.Controllers;
using System.Web.Mvc;
using RestaurantReviewsLibrary;

namespace RestaurantReviewsWeb_Tests
{ 
[TestClass]
    public class RestaurantContoller_Test
    {
        
        [TestMethod]
        public void ModelNameTest()
        {
        RestaurantController controller = new RestaurantController();

        var detailCheck = controller.Details(3) as ViewResult;
        var actual = detailCheck.Model as Restaurant;

        Assert.AreEqual("Boston Market", actual.RestaurantName, "Actual resul = "+actual.RestaurantName);
        }

        [TestMethod]
        public void ModelCityTest()
        {
            RestaurantController controller = new RestaurantController();

            var detailCheck = controller.Details(3) as ViewResult;
            var actual = detailCheck.Model as Restaurant;

            Assert.AreEqual("Tampa", actual.RestaurantCity);
        }

        [TestMethod]
        public void ModelStateTest()
        {
            RestaurantController controller = new RestaurantController();

            var detailCheck = controller.Details(1) as ViewResult;
            var actual = detailCheck.Model as Restaurant;

            Assert.AreEqual("OH", actual.RestaurantState);
        }
        [TestMethod]
        public void ModelIdTest()
        {
            RestaurantController controller = new RestaurantController();

            var detailCheck = controller.Details(3) as ViewResult;
            var actual = detailCheck.Model as Restaurant;

            Assert.AreEqual(3, actual.Id);
        }
        [TestMethod]
        public void ModelURLTest()
        {
            RestaurantController controller = new RestaurantController();

            var detailCheck = controller.Details(4) as ViewResult;
            var actual = detailCheck.Model as Restaurant;

            Assert.AreEqual("qdoba.com", actual.RestaurantURL);
        }
    }
}
