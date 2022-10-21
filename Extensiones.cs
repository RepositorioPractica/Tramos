using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using System.Text.Json;

namespace TestProject1
{
    public static class Extensiones
    {
        public static async Task<T> GetAndDeserialize<T>(this HttpClient client, string requestUri, ITestOutputHelper output = null)
        {

            /* var response = await client.GetAsync(requestUri);
    output?.WriteLine($"Requesting {requestUri}");
    response.EnsureSuccessStatusCode();
    var stringResponse = await response.Content.ReadAsStringAsync();
    output?.WriteLine($"Response: {stringResponse}");
    var result = JsonSerializer.Deserialize<T>(stringResponse,Constants.DefaultJsonOptions);

    return result;*/
           var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);

            // Note: this can be turned into a one-liner starting from .NET 5, or with the System.Net.Http.Json package
            // return client.GetFromJsonAsync<T>(requestUri);
        }
    }
}
