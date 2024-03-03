using System;
using System.Collections.Generic;
using System.Text;

namespace RexpayLibrary.Models
{
    public class TransactionStatusResponse
    {
        public string? amount { get; set; }
        public string? paymentReference { get; set; }
        public string? transactionDate { get; set; }
        public string? currency { get; set; }
        public double fees { get; set; }
        public string? channel { get; set; }
        public string? responseCode { get; set; }
        public string? responseDescription { get; set; }
    }
}
