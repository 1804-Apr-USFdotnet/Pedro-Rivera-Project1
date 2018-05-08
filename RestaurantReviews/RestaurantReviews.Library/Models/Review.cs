using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(25, ErrorMessage = "Reviewer Name should be within 25 characters")]
        public string ReviewerName { get => reviewerName; set => reviewerName = value; }
        [Required]
        [StringLength(50, ErrorMessage = "Review Commment should be within 50 characters")]
        public string ReviewText { get => reviewText; set => reviewText = value; }
        [Required]
        [Range(1,5)]
        public float ReviewScore { get => reviewScore; set => reviewScore = value; }
        [Key]
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
