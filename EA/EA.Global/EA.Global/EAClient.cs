using EA.Global.Auth;
using EA.Global.Statics;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EA.Global
{
    internal class EAClient
    {
        private readonly HttpClient _api;

        private async Task<string> GetToken()
        {
            return await Task.FromResult(EAConfig.EAKey);
        }

        public EAClient()
        {
            _api = new HttpClient(new AuthenticatedHttpClientHandler(GetToken)) { BaseAddress = new Uri(EAConfig.ApiRoot) };

            _api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
        }


        public async Task<string> CsvNonPolling(string enrollNo, string billingPeriod)
        {
            var suffix = $"v3/enrollments/{enrollNo}/usagedetails/download?billingPeriod={billingPeriod}";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> BalanceSummary(string enrollNo)
        {
            var suffix = $"v3/enrollments/{enrollNo}/balancesummary";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> RReservedInstances(string enrollNo, string start, string end)
        {
            var suffix = $"v2/enrollments/{enrollNo}/reservationdetails?startDate={start}&endDate={end}";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> RReservedInstancesCharges(string enrollNo, string start, string end)
        {
            var suffix = $"v2/enrollments/{enrollNo}/reservationcharges?startDate={start}&endDate={end}";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> RReservedInstancesRecommendations(string enrollNo, int lookBackPeriod)
        {
            var suffix = $"v2/enrollments/{enrollNo}/SharedReservationRecommendations?lookBackPeriod={lookBackPeriod}";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> EAPrice(string enrollNo)
        {
            var suffix = $"v3/enrollments/{enrollNo}/pricesheet";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> EAPriceBillingPeriod(string enrollNo, string billingPeriod)
        {
            var suffix = $"v3/enrollments/{enrollNo}/billingPeriods/{billingPeriod}/pricesheet";
            var request = new HttpRequestMessage(HttpMethod.Get, suffix)
            {
                Headers = {
                  //  { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };
            var response = await _api.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
