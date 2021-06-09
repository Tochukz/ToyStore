using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyStore.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { set; get; }

		public int OrderId { set; get; }

		public string Username { set; get; }

		public int ProductId { set; get; }

		public int Quantity  { set; get; }

		public double? UnitPrice { set; get; }
	}
}