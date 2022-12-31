using FoodSpace.Models;

namespace FoodSpace.Data
{
    public class SearchCriteria
    {
        public string criteria { get; set; }
        public int pageSize { get; set; } = 50;
    }
}
