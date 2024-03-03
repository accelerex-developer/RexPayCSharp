using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RexpayLibrary.Models
{
    public class TransactionStatusDto
    {
        [Required(ErrorMessage = "Please provide the mode to process request either test ot production")]
        public string? Mode { get; set; }
        public string? ReferenceNumber { get; set; }

    }
}
