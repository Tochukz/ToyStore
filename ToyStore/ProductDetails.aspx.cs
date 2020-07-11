using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToyStore.Models;

namespace ToyStore
{
	public partial class ProductDetails : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public IQueryable<Product> GetProduct([QueryString("productId")] int? productId)
		{
			ProductContext db = new ProductContext();
			IQueryable<Product> products = db.Products;
			if (productId.HasValue && productId > 0)
			{
				products = products.Where(p => p.ProductID == productId);
			} 
			else
			{
				products = null;
			}
			return products;
		}
	}
}