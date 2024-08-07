using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BE.Helpers
{
    public sealed class PaypalClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private string PaypalClientId { get; }
        private string PaypalClientSecret { get; }
        private string PaypalUrl { get; }

        public string BaseUrl => PaypalUrl == "Live"
            ? "https://api-m.paypal.com"
            : "https://api-m.sandbox.paypal.com";

        public PaypalClient(string clientId, string clientSecret, string mode)
        {
            PaypalClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            PaypalClientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            PaypalUrl = mode ?? throw new ArgumentNullException(nameof(mode));
        }

        private async Task<AuthResponse> Authenticate()
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{PaypalClientId}:{PaypalClientSecret}"));

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/v1/oauth2/token")
            {
                Headers = { { "Authorization", $"Basic {auth}" } },
                Content = content
            };

            var httpResponse = await HttpClient.SendAsync(request);
            httpResponse.EnsureSuccessStatusCode();
            
            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<AuthResponse>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if (response == null || response.AccessToken == null)
            {
                throw new InvalidOperationException("Failed to retrieve access token.");
            }

            return response;
        }

        public async Task<CreateOrderResponse> CreateOrder(string value, string currency, string reference)
        {
            var auth = await Authenticate();

            var request = new CreateOrderRequest
            {
                Intent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnit>
                {
                    new PurchaseUnit
                    {
                        ReferenceId = reference,
                        Amount = new Amount
                        {
                            CurrencyCode = currency,
                            Value = value
                        }
                    }
                },
                ApplicationContext = new ApplicationContext{
                    ReturnUrl = "https://groupcooked.web.app/pay-success",
                    CancelUrl = "https://groupcooked.web.app/pay-success"
                }
            };

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
            var httpResponse = await HttpClient.PostAsJsonAsync($"{BaseUrl}/v2/checkout/orders", request);
            httpResponse.EnsureSuccessStatusCode();
            
            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CreateOrderResponse>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if (response == null)
            {
                throw new InvalidOperationException("Failed to create order.");
            }

            return response;
        }

        public async Task<CaptureOrderResponse> CaptureOrder(string orderId)
        {
            try
            {
                var auth = await Authenticate();
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);

                Console.WriteLine($"Sending capture request for orderId: {orderId}");

                var content = new StringContent("{}", Encoding.UTF8, "application/json");
                var httpResponse = await HttpClient.PostAsync($"{BaseUrl}/v2/checkout/orders/{orderId}/capture", content);

                Console.WriteLine($"Response status code: {httpResponse.StatusCode}");
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {responseContent}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"CaptureOrder failed with status code: {httpResponse.StatusCode}, response: {responseContent}");
                }

                var response = JsonSerializer.Deserialize<CaptureOrderResponse>(responseContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                
                if (response == null)
                {
                    throw new InvalidOperationException("Failed to capture order.");
                }

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"CaptureOrder failed: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }
    }

    public sealed class AuthResponse
    {
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("app_id")]
        public string? AppId { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("nonce")]
        public string? Nonce { get; set; }
    }

    public sealed class CreateOrderRequest
    {
        [JsonPropertyName("intent")]
        public string? Intent { get; set; }
        [JsonPropertyName("purchase_units")]
        public List<PurchaseUnit> PurchaseUnits { get; set; } = new List<PurchaseUnit>();
        [JsonPropertyName("application_context")]
        public ApplicationContext? ApplicationContext { get; set; }
    }

    public sealed class ApplicationContext
    {
        [JsonPropertyName("return_url")]
        public string? ReturnUrl { get; set; }
        [JsonPropertyName("cancel_url")]
        public string? CancelUrl { get; set; }
    }

    public sealed class CreateOrderResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("links")]
        public List<Link> Links { get; set; } = new List<Link>();
    }

    public sealed class CaptureOrderResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("payment_source")]
        public PaymentSource? PaymentSource { get; set; }
        [JsonPropertyName("purchase_units")]
        public List<PurchaseUnit> PurchaseUnits { get; set; } = new List<PurchaseUnit>();
        [JsonPropertyName("payer")]
        public Payer? Payer { get; set; }
        [JsonPropertyName("links")]
        public List<Link> Links { get; set; } = new List<Link>();
    }

    public sealed class PurchaseUnit
    {
        [JsonPropertyName("amount")]
        public Amount? Amount { get; set; }
        [JsonPropertyName("reference_id")]
        public string? ReferenceId { get; set; }
        [JsonPropertyName("shipping")]
        public Shipping? Shipping { get; set; }
        [JsonPropertyName("payments")]
        public Payments? Payments { get; set; }
    }

    public sealed class Payments
    {
        [JsonPropertyName("captures")]
        public List<Capture> Captures { get; set; } = new List<Capture>();
    }

    public sealed class Shipping
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }
    }

    public sealed class Capture
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("amount")]
        public Amount? Amount { get; set; }
        [JsonPropertyName("seller_protection")]
        public SellerProtection? SellerProtection { get; set; }
        [JsonPropertyName("final_capture")]
        public bool FinalCapture { get; set; }
        [JsonPropertyName("disbursement_mode")]
        public string? DisbursementMode { get; set; }
        [JsonPropertyName("seller_receivable_breakdown")]
        public SellerReceivableBreakdown? SellerReceivableBreakdown { get; set; }
        [JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }
        [JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }
        [JsonPropertyName("links")]
        public List<Link> Links { get; set; } = new List<Link>();
    }

    public sealed class Amount
    {
        [JsonPropertyName("currency_code")]
        public string? CurrencyCode { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public sealed class Link
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }
        [JsonPropertyName("rel")]
        public string? Rel { get; set; }
        [JsonPropertyName("method")]
        public string? Method { get; set; }
    }

    public sealed class Name
    {
        [JsonPropertyName("given_name")]
        public string? GivenName { get; set; }
        [JsonPropertyName("surname")]
        public string? Surname { get; set; }
    }

    public sealed class SellerProtection
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("dispute_categories")]
        public List<string> DisputeCategories { get; set; } = new List<string>();
    }

    public sealed class SellerReceivableBreakdown
    {
        [JsonPropertyName("gross_amount")]
        public Amount? GrossAmount { get; set; }
        [JsonPropertyName("paypal_fee")]
        public PaypalFee? PaypalFee { get; set; }
        [JsonPropertyName("net_amount")]
        public Amount? NetAmount { get; set; }
    }

    public sealed class Paypal
    {
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
        [JsonPropertyName("email_address")]
        public string? EmailAddress { get; set; }
        [JsonPropertyName("account_id")]
        public string? AccountId { get; set; }
    }

    public sealed class PaypalFee
    {
        [JsonPropertyName("currency_code")]
        public string? CurrencyCode { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public sealed class Address
    {
        [JsonPropertyName("address_line_1")]
        public string? AddressLine1 { get; set; }
        [JsonPropertyName("address_line_2")]
        public string? AddressLine2 { get; set; }
        [JsonPropertyName("admin_area_2")]
        public string? AdminArea2 { get; set; }
        [JsonPropertyName("admin_area_1")]
        public string? AdminArea1 { get; set; }
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }
    }

    public sealed class Payer
    {
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
        [JsonPropertyName("email_address")]
        public string? EmailAddress { get; set; }
        [JsonPropertyName("payer_id")]
        public string? PayerId { get; set; }
    }

    public sealed class PaymentSource
    {
        [JsonPropertyName("paypal")]
        public Paypal? Paypal { get; set; }
    }
}
