using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models;

public class Item
{
	[Key]
	public int Id { get; set; }
	[Required]
	[MaxLength(64, ErrorMessage = "Max Length is 64 Characters!")]
    public string Name { get; set; }
	[DisplayName("Display Order")]
	//[Range(1,100, ErrorMessage = "Please enter a value between 1 and 100!")]
	public int DisplayOrder { get; set; } = 0;
    public int ServingSize { get; set; } = 0;
    public string ServingDesc { get; set; } = "Default";
    public bool AllerginNuts { get; set; }
    public bool AllerginSoy { get; set; }
    public bool AllerginLactose { get; set; }
    public int Energy { get; set; } = 0;
	public float Protein { get; set; } = 0;
	public float Fat { get; set; } = 0;
    public float Carbohydrates { get; set; } = 0;
    public float DietaryFibre { get; set; } = 0;
    public DateTime CreatedDateTime { get; set;} = DateTime.Now;
}