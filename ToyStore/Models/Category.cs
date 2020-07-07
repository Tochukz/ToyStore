using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
	public class Category
	{
		[ScaffoldColumn(false)]
		public int CategoryID { set; get; }

		[Required, StringLength(100), Display(Name = "Name")]
		public string CategoryName { set; get; }

		[Display(Name = "Product Desciption")]
		public string Description { set; get; }

		public virtual ICollection<Product> Products { get; set; }

	}
}