using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models
{
    public class Step

    {
        [Key]
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public Recipe Recipe { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}