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
    }
}