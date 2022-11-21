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
	[Range(1,100, ErrorMessage = "Please enter a value between 1 and 100!")]
	public int DisplayOrder { get; set; }
    public int ServingSize { get; set; }
    public string ServingSizeDesc { get; set; }
    public bool AllerginNuts { get; set; }
    public bool AllerginSoy { get; set; }
    public bool AllerginLactose { get; set; }
    public int Energy { get; set; }
	public float Protein { get; set; }
	public float Fat { get; set; }
	public float Carbohydrates { get; set; }
	public float DietaryFibre { get; set; }
	public DateTime CreatedDateTime { get; set;} = DateTime.Now;
}