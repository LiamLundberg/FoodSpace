using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FoodSpace.Models;

    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "Max Length is 64 Characters!")]
        public string Name { get; set; }
        public string Desc { get; set; }
        public int ItemsListID { get; set; }
        [DisplayName("Display Order")]
        //[Range(1,100, ErrorMessage = "Please enter a value between 1 and 100!")]
        public int DisplayOrder { get; set; }
        public int ServingSize { get; set; }
        public string ServingDesc { get; set; } = String.Empty;
        public bool AllerginNuts { get; set; }
        public bool AllerginSoy { get; set; }
        public bool AllerginLactose { get; set; }
        public int Energy { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float DietaryFibre { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }

