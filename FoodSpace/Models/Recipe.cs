using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSpace.Models;

    
    public class Recipe
    {

    [Key]
    public int RecipeId { get; set; }
    [Required]
    [MaxLength(64, ErrorMessage = "Max Length is 64 Characters!")]
    public string Name { get; set; }
    public string Desc { get; set; }
    public virtual ICollection<ItemRecipe> ItemRecipe { get; set; }
    [DisplayName("Display Order")]
    //[Range(1,100, ErrorMessage = "Please enter a value between 1 and 100!")]
    public int DisplayOrder { get; set; }
    public int ServingSize { get; set; }
    public string ServingDesc { get; set; } = String.Empty;
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }

