using Microsoft.AspNetCore.Mvc;
using RexpayLibrary;
using RexpayLibrary.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPayment _payment;
       

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPayment payment)
        {
            _logger = logger;
            _payment = payment;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            CreatePaymentRequestDto request = new CreatePaymentRequestDto
            {
                Mode = "test",
                ReferenceNumber = "sm23oyr1122",
                CustomerName = "customer_name",
                Amount = 100.0,
                Email = "awoyeyetimilehin@gmail.com",
                UserId = "awoyeyetimilehin@gmail.com",
                CallbackUrl = "https://example.com/callback"
            };

            CreateRequestResponse response = await _payment.CreatePayment(request, "talk2phasahsyyahoocom",
                "f0bedbea93df09264a4f09a6b38de6e9b924b6cb92bf4a0c07ce46f26f85");

            TransactionStatusDto transactionStatusDto = new TransactionStatusDto
            {
                Mode = "test",
                ReferenceNumber = "sm23oyr1122"
            };

            TransactionStatusResponse statusResponse = await _payment.GetTransactionStatus(transactionStatusDto, "talk2phasahsyyahoocom", "f0bedbea93df09264a4f09a6b38de6e9b924b6cb92bf4a0c07ce46f26f85");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }
    }
}
