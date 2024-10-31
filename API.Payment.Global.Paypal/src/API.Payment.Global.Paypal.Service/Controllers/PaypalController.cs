using API.Payment.Global.Paypal.Domain.Implementation.Interfaces;
using API.Payment.Global.Paypal.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace API.Payment.Global.Paypal.Service.Controllers
{
	[Route("v1/payment/paypal")]
	[ApiController]
	[ApiExplorerSettings(GroupName = "paypal")]
	public class PaypalController : ControllerBase
	{
		private readonly ILogger<PaypalController> _logger;

		private readonly IPaypalService _paypalService;

		public PaypalController(
				ILogger<PaypalController> logger,
				IPaypalService paypalService
			)
		{
			_logger = logger;
			_paypalService = paypalService;
		}

		[HttpPost("create-order")]
		public async Task<IActionResult> Order([FromBody] CreateOrderInput createOrderInput, CancellationToken cancellationToken)
		{
			try
			{
				var response = await _paypalService.CreateOrder(createOrderInput.Price, createOrderInput.Currency, createOrderInput.Reference);

				return Ok(response);
			}
			catch (Exception e)
			{
				var error = new
				{
					e.GetBaseException().Message
				};

				return BadRequest(error);
			}
		}

		[HttpGet("{orderId}/capture")]
		public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
		{
			try
			{
				var response = await _paypalService.CaptureOrder(orderId);

				foreach (var item in response.links)
				{
					if (item.href.Contains("ORDER_NOT_APPROVED"))
					{
						var error = new
						{
							Message = "ORDER_NOT_APPROVED"
						};

						return BadRequest(error);
					}
				}

				var reference = response.purchase_units[0].reference_id;

				return Ok(response);
			}
			catch (Exception e)
			{
				var error = new
				{
					e.GetBaseException().Message
				};

				return BadRequest(error);
			}
		}
	}
}