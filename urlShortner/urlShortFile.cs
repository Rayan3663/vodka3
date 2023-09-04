using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class UrlShortenerService
{
    private const string ApiKey = "5b0a4577c46f4f3ea4749c7373061db9";
    //private const string Workspace = "";
    private const string BaseUrl = "https://api.rebrandly.com";

    public async Task<string> ShortenUrlAsync(string destinationUrl)
    {
        var payload = new
        {
            destination = destinationUrl
        };

        using (var httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) })
        {
            httpClient.DefaultRequestHeaders.Add("apikey", ApiKey);
            //httpClient.DefaultRequestHeaders.Add("workspace", Workspace);

            var body = new StringContent(
                JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync("/v1/links", body))
            {
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic link = JsonConvert.DeserializeObject(jsonResponse);

                return link.shortUrl;
            }
        }
    }
}
