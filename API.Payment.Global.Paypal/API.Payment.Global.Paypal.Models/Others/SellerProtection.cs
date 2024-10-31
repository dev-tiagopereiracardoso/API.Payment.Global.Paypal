namespace API.Payment.Global.Paypal.Models.Others
{
	public class SellerProtection
	{
		public string status { get; set; }
		public List<string> dispute_categories { get; set; }
	}
}
