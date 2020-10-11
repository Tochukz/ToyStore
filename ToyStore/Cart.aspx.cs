using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToyStore.Logic;
using ToyStore.Models;

namespace ToyStore
{
	public partial class Cart : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			using (CartActions usersCart = new CartActions())
			{
				decimal cartTotal = 0;
				cartTotal = usersCart.GetTotal();
				if (cartTotal > 0)
				{
					lblTotal.Text = String.Format("{0:c}", cartTotal);
				}
				else
				{
					LabelTotalText.Text = "";
					lblTotal.Text = "";
					CartTitle.InnerText = "Shopping Cart is Empty";
					UpdateBtn.Visible = false;
				}
			}

		}

		public List<CartItem> GetCartItems()
		{
			CartActions actions = new CartActions();
			return actions.GetCartItems();
		}

		
		public List<CartItem> UpdateCartItems()
		{
			using (CartActions usersCart = new CartActions())
			{
				String cartId = usersCart.GetCartId();
				CartActions.CartUpdates[] cartUpdates = new CartActions.CartUpdates[CartList.Rows.Count];
				for (int i = 0; i < CartList.Rows.Count; i++)
				{
					IOrderedDictionary rowValues = new OrderedDictionary();
					rowValues = GetValues(CartList.Rows[i]);
					cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

					CheckBox cbRemove = new CheckBox();
					cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
					cartUpdates[i].RemoveItem = cbRemove.Checked;

					TextBox quantityTextBox = new TextBox();
				    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
					cartUpdates[i].PurchaseQunatity = Convert.ToInt16(quantityTextBox.Text.ToString());
				}
				usersCart.UpdateCartDatabase(cartId, cartUpdates);
				CartList.DataBind();
				lblTotal.Text = String.Format("{0:c}", usersCart.GetTotal());
				return usersCart.GetCartItems();
			}
		}
		

		public static IOrderedDictionary GetValues(GridViewRow row)
		{
			IOrderedDictionary values = new OrderedDictionary();
			foreach (DataControlFieldCell cell in row.Cells)
			{
				if (cell.Visible)
				{
					// EXtract values from the cell.
					cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
				}
			}
			return values;
		}

		protected void UpdateBtn_Click(object sender, EventArgs e)
		{
			UpdateCartItems();
		}
	}
}