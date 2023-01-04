using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSpace.Models
{
    public class ItemRecipe
    {
        
        public int ItemRecipeId { get; set; }
        public int ItemId { get; set; }
        public int RecipeId { get; set; }
        public Item Item { get; set; }
        public Recipe Recipe { get; set; }
    }
}
