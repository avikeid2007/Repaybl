//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.11.1.0 (NJsonSchema v10.4.3.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Repaybl.Swag
{
    public class BaseClient
    {
        public string BaseUrl { get; set; } = "http://repaybl.avnishkumar.co.in/";
        //public string BaseUrl { get; set; } = "http://localhost:46606/";
        private static string bearerToken { get; set; }
        public static void SetBearerToken(string token)
        {
            bearerToken = token;
        }
        // Called by implementing swagger client classes
        protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();
            if (!string.IsNullOrEmpty(bearerToken))
                msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            return Task.FromResult(msg);
        }
        protected async Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken = default)
        {
//#if __WASM__
//    var innerHandler = new Uno.UI.Wasm.WasmHttpHandler();
//#else
//            var innerHandler = new HttpClientHandler();
//#endif
            var _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseUrl);
            return _client;
        }
    }
}