using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToyStore.Models;

namespace ToyStore
{
	public partial class ProductList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		/* QueryString() as used the this method definition is called a value provider. It is a class of System.Web.ModelBinding.
		 * The argument ("id") passed to the value provider is called the value provider attribute.
		 * There are value provider for user inputs suchs as query string, cookies, form values, controls, view state, session state and profile properties,
		 * You can also write custom value providers.
		 */
		public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
		{
			string CategoryName = "Products";
			ProductContext db = new ProductContext();
			IQueryable<Product> products = db.Products;
			if (categoryId.HasValue && categoryId > 0)
			{
				CategoryName =  db.Categories.Where(c => c.CategoryID == categoryId).Select(c => c.CategoryName).Single<string>();
				products = products.Where(p => p.CategoryID == categoryId);
			}
			pageTitle.InnerText = CategoryName;
			return products;
		}
	}
}