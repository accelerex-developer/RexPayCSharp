

namespace RexpayLibrary.Models
{
    public class CreatePaymentRequest
    {
        public string? reference { get; set; }
        public double amount { get; set; }
        public string? currency { get; set; }
        public string? userId { get; set; }
        public string? callbackUrl { get; set; }
        public Metadata? metadata { get; set; }
    }

    public class Metadata
    {
        public string? email { get; set; }
        public string? customerName { get; set; }
    }
}

