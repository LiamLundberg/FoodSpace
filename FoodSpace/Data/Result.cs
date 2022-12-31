using FoodSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodSpace.Data
{
    public class Result
    {
        public Result() {
        
        }

        public FoodSearchResult result { get; set; }
    }
}
