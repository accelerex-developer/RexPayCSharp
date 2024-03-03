using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RexpayLibrary.Models
{
    public class CreatePaymentRequestDto
    {
        [Required(ErrorMessage = "Please provide the mode to process request either test ot production")]
        public string? Mode { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? CustomerName { get; set; }
        public double Amount { get; set; }
        public string? Email { get; set; }
        public string? UserId { get; set; }
        public string? CallbackUrl { get; set; }
    }
}
