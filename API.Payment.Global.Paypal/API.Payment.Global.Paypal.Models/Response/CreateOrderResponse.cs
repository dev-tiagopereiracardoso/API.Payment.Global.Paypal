using API.Payment.Global.Paypal.Models.Others;

namespace API.Payment.Global.Paypal.Models.Response
{
	public sealed class CreateOrderResponse
	{
		public string id { get; set; }
		public string status { get; set; }
		public List<Link> links { get; set; }
	}
}
