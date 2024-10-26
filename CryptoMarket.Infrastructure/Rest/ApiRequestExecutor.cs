using CryptoMarket.Domain.Rest;
using Newtonsoft.Json;

namespace CryptoMarket.Infrastructure.Rest;

public class ApiRequestExecutor : IApiRequestExecutor
{
    private readonly IHttpClientFactory _httpClientFactory; 
    string server = "https://api.coincap.io/v2/";
    private readonly Uri _baseAddress;
    public ApiRequestExecutor(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _baseAddress = new Uri(server);
    }
    public async Task<TResponse> GetAsync<TResponse>(string request)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = _baseAddress;

        var httpResponceMessage = await httpClient.GetAsync(request);

        var content = await httpResponceMessage.Content.ReadAsStringAsync();


        var responce = JsonConvert.DeserializeObject<TResponse>(content);

        return responce;
    }
}