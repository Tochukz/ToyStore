using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
	public class Product
	{
		[ScaffoldColumn(false)]
		public int ProductID { set; get; }

		[Required, StringLength(100), Display(Name = "Name")]
		public string ProductName { set; get; }

		[Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
		public string Description { set; get; }

		public string ImagePath { set; get; }

		[Display(Name = "Price")]
		public double? UnitPrice { set; get; }

		public int? CategoryID { set; get; }

		public virtual Category Category { get; set; }
	}
}