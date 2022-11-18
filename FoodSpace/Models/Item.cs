using Microsoft.AspNetCore.Mvc;

namespace FoodSpace.Models;

public class Item
{
	public int Id  { get; set; }
	public string Name { get; set; }
	public int DisplayOrder { get; set; }
	public DateTime CreatedDateTime { get; set;} = DateTime.Now;
}


