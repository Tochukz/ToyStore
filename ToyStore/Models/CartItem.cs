using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
	public class CartItem
	{
		[Key]
		public string ItemID { set; get; }
	
		public string CartID { set; get; }

		public int Quantity { set; get; }

		public System.DateTime DateCreated { set; get; }

		public int ProductID { set; get; }

		public virtual Product Product { set; get; }
	}
}

/* 
 * By convention Entity Framewok Code First expects that the primary key for tha CartItem table will be either CardItemId or ID
 * The [key] attribute overrides this default behaviour. The Key attribute specifies that the ItemID property is the primary key.
 *
 * The CartId specifies the ID of the user
 */
