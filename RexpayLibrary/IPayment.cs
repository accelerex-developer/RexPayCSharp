using RexpayLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RexpayLibrary
{
    public interface IPayment
    {
        Task<CreateRequestResponse> CreatePayment(CreatePaymentRequestDto request, string username, string password);
        Task<TransactionStatusResponse> GetTransactionStatus(TransactionStatusDto transactionStatusDto, string username, string password);
    }
}
