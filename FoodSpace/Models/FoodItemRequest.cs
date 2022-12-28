namespace FoodSpace.Models
{
    public class FoodItemRequest
    {
        public FoodItemRequest()
        {
                
        }

        public string Query { get; set; }
        public int PageSize { get; set; }
        public string Api_Key { get; set; }
    }
}
