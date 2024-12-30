using System.Net.Http;
using System.Net.Http.Json;
using DataAccessLibrary.Models;

namespace MauiBlazorApp.Web.Services;

public class DeutschAdjSuffixService
{
    private readonly HttpClient _httpClient;

    public DeutschAdjSuffixService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DeutschAdjSuffix>> GetDeuAdjSuffixAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<DeutschAdjSuffix>>("deutschadjsuffix");
    }
}
