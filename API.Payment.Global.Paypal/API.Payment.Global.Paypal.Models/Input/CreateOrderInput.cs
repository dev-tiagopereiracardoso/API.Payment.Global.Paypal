namespace API.Payment.Global.Paypal.Models.Input
{
	public class CreateOrderInput
	{
		public string Price { set; get; }

		public string Currency { set; get; }

		public string Reference { set; get; }
	}
}