using API.Payment.Global.Paypal.Models.Others;

namespace API.Payment.Global.Paypal.Models.Request
{
	public class CreateOrderRequest
	{
		public string intent { get; set; }
		public List<PurchaseUnit> purchase_units { get; set; } = new();
	}
}
