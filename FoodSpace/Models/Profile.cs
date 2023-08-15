using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models
{
    public class Profile
    {
        public Profile() { }

        [Key]
        public int ProfileID { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "Max Length is 64 Characters!")]
        public string ProfileName { get; set; } = "Default";
        public byte[] ProfilePicture { get; set; }

        //preferences tolerance
        public bool Prefernce_Vegan { get; set; }
        public bool Prefernce_Vegetarian { get; set; }
        public bool Prefernce_GlutenFree { get; set; }
        public bool Prefernce_NutFree { get; set; }
        public bool Prefernce_LactoseFree { get; set; }

        //preferences caloric
        public int MaxCalories { get; set; }
        public int MinProtein { get; set;}
        public int MaxFat { get; set;}
        public int MinCarbohydrates { get; set; }
    }

}