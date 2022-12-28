using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models
{
    public class RecipeItems
    {
        [Key]
        public int Id { get; set; }
        public Recipe recipe { get; set; }
        public Item Item { get; set; }
    }
}
