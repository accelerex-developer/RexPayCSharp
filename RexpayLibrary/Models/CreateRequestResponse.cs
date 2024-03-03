using System;
using System.Collections.Generic;
using System.Text;

namespace RexpayLibrary.Models
{
    public class CreateRequestResponse
    {
        public string? reference { get; set; }
        public string? clientId { get; set; }
        public string? paymentUrl { get; set; }
        public string? status { get; set; }
        public string? paymentChannel { get; set; }
        public string? paymentUrlReference { get; set; }
        public string? externalPaymentReference { get; set; }
        public double fees { get; set; }
        public string? currency { get; set; }
    }
}
