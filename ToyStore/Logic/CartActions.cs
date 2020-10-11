using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using ToyStore.Models;

namespace ToyStore.Logic
{
	public class CartActions: IDisposable
	{
		public string CartID { set; get; }

		private ProductContext db = new ProductContext();

		public const string CartSessionKey = "CartId";

		public void AddToCart(int id)
		{
			CartID = GetCartId();
			CartItem cartItem = db.CartItems.SingleOrDefault(c => c.CartID == CartID && c.ProductID == id);
		    if (cartItem == null)
			{
				cartItem = new CartItem
				{
					ItemID = Guid.NewGuid().ToString(),
					ProductID = id,
					CartID = CartID,
					Product = db.Products.SingleOrDefault(p => p.ProductID == id),
					Quantity = 1,
					DateCreated = DateTime.Now
				};
				db.CartItems.Add(cartItem);
			}
			else
			{
				cartItem.Quantity++;
			}
			db.SaveChanges();
		}

		
		public string GetCartId()
		{
			if (HttpContext.Current.Session[CartSessionKey] == null)
			{
				if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
				{
					HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
				}
				else
				{
					Guid tempCartId = Guid.NewGuid();
					HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
				}
			}
			return HttpContext.Current.Session[CartSessionKey].ToString();
		}

		public List<CartItem> GetCartItems()
		{
			CartID = GetCartId();
			return db.CartItems.Where(c => c.CartID == CartID).ToList();
		}

		public decimal GetTotal()
		{
			CartID = GetCartId();
			decimal? total = decimal.Zero;
			total = (decimal?)(from cartItems in db.CartItems
							   where cartItems.CartID == CartID
							   select (int?)cartItems.Quantity * cartItems.Product.UnitPrice).Sum();
			return total ?? decimal.Zero;
		}

		public CartActions GetCart(HttpContext context)
		{
			using (CartActions cart = new CartActions())
			{
				cart.CartID = cart.GetCartId();
				return cart;
			}
		}

		public void RemoveItem(string removeCartId, int removeProductID)
		{
			using (ProductContext db = new ProductContext())
			{
				try
				{
					var myItem = (from c in db.CartItems
								  where c.CartID == removeCartId && c.Product.ProductID == removeProductID
								  select c).FirstOrDefault();
					if (myItem != null)
					{
						// Remove Item
						db.CartItems.Remove(myItem);
						db.SaveChanges();
					}
				}
				catch(Exception exp)
				{
					throw new Exception("ERROR: Unable to romove Cart Item - " + exp.Message.ToString(), exp);
				}
			}
		}

		public void UpdateItem(string updateCartID, int updateProductID, int quantity)
		{
			using (ProductContext db = new ProductContext())
			{
				try
				{
					CartItem myItem = (from c in db.CartItems
									   where c.CartID == updateCartID && c.Product.ProductID == updateProductID
									   select c).FirstOrDefault();
					if (myItem != null)
					{
						myItem.Quantity = quantity;
						db.SaveChanges();
					}
				}
				catch (Exception exp)
				{
					throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
				}
			}
		}

		public void EmptyCart()
		{
			CartID = GetCartId();
			IQueryable cartItems = db.CartItems.Where(c => c.CartID == CartID);
			foreach (CartItem cartItem in cartItems)
			{
				db.CartItems.Remove(cartItem);
			}
			db.SaveChanges();
		}

		public int GetCount()
		{
			CartID = GetCartId();
			// Get the count of each item in the cart and sum them up
			int? count = (from CartItem in db.CartItems
						  where CartItem.CartID == CartID
						  select (int?)CartItem.Quantity).Sum();
			return count ?? 0;
		}

		public void Dispose()
		{
			if ( db != null)
			{
				db.Dispose();
				db = null;
			}
		}

		public struct CartUpdates
		{
			public int ProductId;
			public int PurchaseQunatity;
			public bool RemoveItem;
		}

		public void UpdateCartDatabase(string cartId, CartUpdates[] CartItemUpdates)
		{
			using (ProductContext db = new ProductContext())
			{
				try
				{
					int CartItemCount = CartItemUpdates.Count();
					List<CartItem> myCart = GetCartItems();
					foreach(CartItem cartItem in myCart)
					{
						for (int i = 0; i < CartItemCount; i++)
						{
							if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
							{
								if (CartItemUpdates[i].PurchaseQunatity < 1 || CartItemUpdates[i].RemoveItem == true)
								{
									RemoveItem(cartId, cartItem.ProductID);
								}
								else
								{
									UpdateItem(cartId, cartItem.ProductID, CartItemUpdates[i].PurchaseQunatity);
								}
							}
						}
					}
				}
				catch(Exception ex)
				{
					throw new Exception($"ERROR: Unable to Update Cart Database - {ex.Message}", ex);
				}
			}
		}
		
	}
}