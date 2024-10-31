namespace API.Payment.Global.Paypal.Models.Others
{
	public class PurchaseUnit
	{
		public Amount amount { get; set; }
		public string reference_id { get; set; }
		public Shipping shipping { get; set; }
		public Payments payments { get; set; }
	}
}
