using System.Data.Entity;

namespace ToyStore.Models
{
	public class ProductContext: DbContext
	{
		public ProductContext() : base("ToyStore")
		{

		}

		public DbSet<Category> Categories { set; get; }

		public DbSet<Product> Products { set; get; }

		public DbSet<CartItem> CartItems { set; get; }
	}
}