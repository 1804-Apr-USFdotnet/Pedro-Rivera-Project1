using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviewsLibrary;

namespace RestaurantReviewsTests
{
    [TestClass]
    public class Tests
    {
        private Restaurant restaurant1 = new Restaurant
        {
            RestaurantAddress = "14162 Kedzie Circle",
            RestaurantCity = "Warren",
            RestaurantName = "Schinner-Hoppe",
            RestaurantState = "OH",
            RestaurantPhoneNumber = "330-322-1739",
            RestaurantURL = "http://examiner.com",
            CustomerRating = 1.0f
        };

        private Restaurant restaurant2 = new Restaurant
        {
            RestaurantAddress = "123 Name Circle",
            RestaurantCity = "Boston",
            RestaurantName = "McDonald's",
            RestaurantState = "MA",
            RestaurantPhoneNumber = "123-456-7891",
            RestaurantURL = "http://website.com",
            CustomerRating = 2.0f
        };

        private Restaurant restaurant3 = new Restaurant
        {
            RestaurantAddress = "12 Something Road",
            RestaurantCity = "Tampa",
            RestaurantName = "Joe's Burgers",
            RestaurantState = "FL",
            RestaurantPhoneNumber = "987-456-1234",
            RestaurantURL = "http://joesburgers.com",
            CustomerRating = 3.0f
        };

        private Restaurant restaurant4 = new Restaurant
        {
            RestaurantAddress = "4th street",
            RestaurantCity = "New York",
            RestaurantName = "Fourth Street Diner",
            RestaurantState = "NY",
            RestaurantPhoneNumber = "123-123-1234",
            RestaurantURL = "http://4thstreet.com",
            CustomerRating = 4.0f
        };

        private List<Restaurant> actualList;
        [TestMethod]
        public void DeserializeFromJSON_Test()
        {
            //Arrange
            Restaurant expected = new Restaurant
            {
                RestaurantAddress = "14162 Kedzie Circle",
                RestaurantCity = "Warren",
                RestaurantName = "Schinner-Hoppe",
                RestaurantState = "OH",
                RestaurantPhoneNumber = "330-322-1739",
                RestaurantURL = "http://examiner.com"
            };

            //Act
            Restaurant actual = Deserialize.FromJson(@"{
              'RestaurantName': 'Schinner-Hoppe',
              'RestaurantAddress': '14162 Kedzie Circle',
              'RestaurantPhoneNumber': '330-322-1739',
              'RestaurantURL': 'http://examiner.com',
              'RestaurantCity': 'Warren',
              'RestaurantState': 'OH'
            }");

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SortByRating_Test()
        {
            actualList = new List<Restaurant>();
            SortLogic sort = new SortLogic();
            actualList.Add(restaurant1);
            actualList.Add(restaurant2);
            actualList.Add(restaurant3);
            actualList.Add(restaurant4);
            Restaurant actual = actualList[3];

            List<Restaurant> expectedList/* = new List<Restaurant>();
            expectedList*/ = (List<Restaurant>)sort.SortByRating(3, actualList);
            Restaurant expected = expectedList[0];

            Assert.AreEqual(actual, expected,expected.CustomerRating+" "+actual.CustomerRating);
        }
        [TestMethod]
        public void SortByNameAscending_Test()
        {
            actualList = new List<Restaurant>();
            SortLogic sort = new SortLogic();
            actualList.Add(restaurant1);
            actualList.Add(restaurant2);
            actualList.Add(restaurant3);
            actualList.Add(restaurant4);

            Restaurant actual = actualList[3];
            List<Restaurant> expectedList = new List<Restaurant>();
            expectedList = (List<Restaurant>)sort.SortByNameAscending(actualList);
            Restaurant expected = expectedList[0];

            Assert.AreEqual(actual, expected,expected.RestaurantName+" "+actual.RestaurantName);

        }
        [TestMethod]
        public void SearchRestaurantByName_Test()
        {
            actualList = new List<Restaurant>();
            SortLogic sort = new SortLogic();
            actualList.Add(restaurant1);
            actualList.Add(restaurant2);
            actualList.Add(restaurant3);
            actualList.Add(restaurant4);
            Restaurant actual = actualList[0];
            List<Restaurant> expectedList = new List<Restaurant>();
            expectedList = (List<Restaurant>)sort.SearchRestaurantByName("M",actualList);
            Restaurant expected = expectedList[0];
            Assert.AreEqual(actual, expected, expected.RestaurantName + " " + actual.RestaurantName);
        }
    }
        

    
}
