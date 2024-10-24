using CryptoMarket.Domain.Rest;
using Newtonsoft.Json;

namespace CryptoMarket.Infrastructure.Rest;

public class ApiRequestExecutor : IApiRequestExecutor
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Uri _baseAdress = new("api.coincap.io/v2/assets");
    public ApiRequestExecutor(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<TResponse> GetAsync<TResponse>(string request)
    {
        using var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = _baseAdress;

        var httpResponceMessage = await httpClient.GetAsync(request);

        var content = await httpResponceMessage.Content.ReadAsStringAsync();


        var responce = JsonConvert.DeserializeObject<TResponse>(content);

        return responce;
    }
}