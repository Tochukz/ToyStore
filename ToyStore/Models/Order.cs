using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
	public class Order
	{
		public int OrderId { set; get; }

		public DateTime OrderDate { set; get; }

		public string Username { set; get; }

		[Required(ErrorMessage = "First Name is required")]
		[DisplayName("First Name")]
		[StringLength(160)]
		public string FirstName { set; get; }

		[Required(ErrorMessage = "Last Name is required")]
		[DisplayName("Last Name")]
		[StringLength(160)]
		public string LastName { set; get; }


		[Required(ErrorMessage = "Address is required")]
		[StringLength(70)]
		public string Address { set; get; }

		[Required(ErrorMessage = "City is required")]
		[StringLength(40)]
		public string City { set; get; }

		[Required(ErrorMessage =  "State is required")]
		[StringLength(40)]
		public string State { set; get; }

		[Required(ErrorMessage = "Postal Code is required")]
		[StringLength(10)]
		public string PostalCode { set; get; }

		[Required(ErrorMessage = "Country is required")]
		[StringLength(40)]
		public string Contry { set; get; }

		[StringLength(24)]
		public string Phone { set; get; }

		[Required(ErrorMessage = "Email address is required")]
		[DisplayName("Email Address")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Your email address is not valid")]
		[DataType(DataType.EmailAddress)]
		public string Email { set; get; }

		[ScaffoldColumn(false)]
		public decimal Total { get; set; }

		[ScaffoldColumn(false)]
		public string PaymentTransactionId { set; get; }

		[ScaffoldColumn(false)]
		public bool HasBeenShipped { set; get; }

		public List<OrderDetail> OrderDetails { set; get; }
	}
}