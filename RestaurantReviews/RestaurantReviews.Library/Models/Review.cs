using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary
{
    public class Review
    {
        public Review()
        {
           
        }
        private int id;
        private string reviewerName;
        private string reviewText;
        private float reviewScore;
        private int restaurantID;
        

        public int RestaurantID { get => restaurantID; set => restaurantID = value; }
        public string ReviewerName { get => reviewerName; set => reviewerName = value; }
        public string ReviewText { get => reviewText; set => reviewText = value; }
        public float ReviewScore { get => reviewScore; set => reviewScore = value; }
        public int Id { get => id; set => id = value; }
        

        public void UpdateName(string _name)
        {
            reviewerName = _name;
        }
        public void UpdateScore(float _value)
        {
            reviewScore = _value;
        }
        public float GetReviewScore()
        {
            return reviewScore;
        }
    }
}
