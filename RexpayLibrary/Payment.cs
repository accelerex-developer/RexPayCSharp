using Newtonsoft.Json;
using RexpayLibrary.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RexpayLibrary
{
    public class Payment : IPayment
    {
        public Payment()
        {
          
        }

        public async Task<CreateRequestResponse> CreatePayment(CreatePaymentRequestDto request, string username, string password)
        {
            string url = request.Mode.Equals("production", StringComparison.OrdinalIgnoreCase)
                ? Enums.liveUrlCreate
                : Enums.testUrlCreate;
            try
            {
                Metadata metaData = new Metadata
                {
                    customerName = request.CustomerName,
                    email = request.Email
                };

                CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest
                {
                    reference = request.ReferenceNumber,
                    amount = request.Amount,
                    currency = "NGN",
                    userId = request.UserId,
                    callbackUrl = request.CallbackUrl,
                    metadata = metaData
                };
                
                var jsonString = JsonConvert.SerializeObject(createPaymentRequest);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var ress = await response.Content.ReadAsStringAsync();                      
                        return JsonConvert.DeserializeObject<CreateRequestResponse>(ress);
                    }
                    else
                    {

                        return new CreateRequestResponse()
                        {
                            status = $"{response.StatusCode} {response.ReasonPhrase}"
                        };
                    }
                }
               
            }
            catch (Exception ex)
            {
                return new CreateRequestResponse()
                {
                    reference = request.ReferenceNumber,
                    status = $"{ex.Message}"
                };
            }
        }

        public async Task<TransactionStatusResponse> GetTransactionStatus(TransactionStatusDto transactionStatusDto, string username, string password)
        {
            string url = transactionStatusDto.Mode.Equals("production", StringComparison.OrdinalIgnoreCase)
                ? Enums.liveUrlQuery
                : Enums.testUrlQuery;
            try
            {
                TransactionStatusRequest request = new TransactionStatusRequest
                {
                    transactionReference = transactionStatusDto.ReferenceNumber
                };

                var jsonString = JsonConvert.SerializeObject(request);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var ress = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TransactionStatusResponse>(ress);
                    }
                    else
                    {

                        return new TransactionStatusResponse()
                        {
                            responseCode = "099",
                            responseDescription = $"{response.StatusCode} {response.ReasonPhrase}"
                        };
                    }
                }
               
            }
            catch (JsonException ex)
            {
                return new TransactionStatusResponse()
                {
                    responseCode = "099",
                    responseDescription = $"{ex.Message}"
                };
            }
        }
    }
}

