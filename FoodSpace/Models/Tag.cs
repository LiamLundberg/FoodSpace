using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FoodSpace.Models
{
    public class Tag
    {
        public Tag() { }

        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ItemTag>? ItemTags { get; set; }
    }
}
