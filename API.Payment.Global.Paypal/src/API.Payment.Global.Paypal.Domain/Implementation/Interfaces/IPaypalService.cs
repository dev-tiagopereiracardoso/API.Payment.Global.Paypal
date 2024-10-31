using API.Payment.Global.Paypal.Models.Response;

namespace API.Payment.Global.Paypal.Domain.Implementation.Interfaces
{
	public interface IPaypalService
	{
		Task<CreateOrderResponse> CreateOrder(string value, string currency, string reference);

		Task<CaptureOrderResponse> CaptureOrder(string orderId);
	}
}