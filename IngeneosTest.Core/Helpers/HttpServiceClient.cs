using System.Net.Http;
using System.Threading.Tasks;

namespace IngeneosTest.Core.Helpers
{
    public static class HttpServiceClient
    {
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<string> Get(string baseAddress)
        {
            string result = string.Empty;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await _client.GetAsync(baseAddress);

            if (responseMessage.IsSuccessStatusCode)
                result = await responseMessage.Content.ReadAsStringAsync();

            return result;
        }
    }
}
