using System.Net.Http.Json;

namespace Berger.Extensions.Http
{
    public static class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<T> ParseAsync<T>(this HttpResponseMessage response)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}