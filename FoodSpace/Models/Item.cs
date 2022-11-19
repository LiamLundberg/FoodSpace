using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodSpace.Models;

public class Item
{
	[Key]
	public int Id  { get; set; }
	[Required]
	public string Name { get; set; }
	[DisplayName("Display Order")]
	[Range(1,100, ErrorMessage = "Please enter a value between 1 and 100!")]
	public int DisplayOrder { get; set; }
	public DateTime CreatedDateTime { get; set;} = DateTime.Now;
}