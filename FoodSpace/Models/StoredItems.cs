﻿using System.Drawing;

namespace FoodSpace.Models
{
    public class FoodSearchResult
    {
        public FoodSearchCriteria foodSearchCriteria { get; set; }
        public string totalHits { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public Foods[] Foods { get; set; }


    }

    public class FoodSearchCriteria
    {
        public string query { get; set; }
    }

    public class Foods
    {
        public int fdcID { get; set; }
        public string description { get; set; }
    }
}