using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TG_Workshop_Web.Helper
{
    /// <summary>
    /// A helper created to read data as Json after sending request to our MicroServices
    /// </summary>
    public static class HttpClientHelper
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            //Return control from http request
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
