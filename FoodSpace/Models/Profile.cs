using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "Max Length is 64 Characters!")]
        public string ProfileName { get; set; }
        public byte[] ProfilePicture { get; set; }

        //preferences
        public bool Prefernce_Vegan { get; set; }
        public bool Prefernce_Vegetarian { get; set; }
        public bool Prefernce_GlutenFree { get; set; }
        public bool Prefernce_NutFree { get; set; }
        public bool Prefernce_LactoseFree { get; set; }
    }
}


