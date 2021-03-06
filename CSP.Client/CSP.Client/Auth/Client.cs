﻿
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;

using CSP.Client.Statics;
using System.Runtime.Serialization.Json;
using System.Net;

namespace CSP.Client.Auth
{
    class Client
    {
        private readonly HttpClient _api;

        AuthenticationContext context = new AuthenticationContext($"{CSPConfig.Authority}/{CSPConfig.ApplicationDomain}");

        private async Task<string> GetToken()
        {
            var clientCred = new ClientCredential(CSPConfig.ApplicationId, CSPConfig.ApplicationSecret);
            var token = await context.AcquireTokenAsync(CSPConfig.ResourceUrl, clientCred);
            return token.AccessToken;
        }

        public Client()
        {
            _api = new HttpClient(new AuthenticatedHttpClientHandler(GetToken)) { BaseAddress = new Uri(CSPConfig.PartnerServiceApiRoot) };

            _api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
        }


        public async Task<string> Test()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "v1/customers?size=40")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString() },
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> TestReferrals()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "partner/v1/analytics/referrals")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> TestIndirectresellers()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "partner/v1/analytics/usage/azure")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> TestDeployment()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"v1/analytics/licenses/deployment")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> TestUsage()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"v1/analytics/licenses/usage")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> TestPartnerUsage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"v1/analytics/licenses/usage")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        // v1/analytics/commercial/deployment/license
        public async Task<string> TestCommercialDeployment()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"v1/analytics/commercial/deployment/license")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> TestCommercialUsage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"v1/analytics/commercial/usage/license")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "MS-RequestId", Guid.NewGuid().ToString() },
                    { "MS-CorrelationId", Guid.NewGuid().ToString() },
                    { "MS-Contract-Version", "v1" },
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<string> GetAllSearchAnalytics()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"partner/v1/analytics/search?top=100")
            {
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { HttpRequestHeader.ContentType.ToString(), "application/json"},
                    //{ "MS-CorrelationId", Guid.NewGuid().ToString() },
                    //{ "MS-Contract-Version", "v1" },
                    //{ "MS-RequestId", Guid.NewGuid().ToString()}
                }
            };


            var response = await _api.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
