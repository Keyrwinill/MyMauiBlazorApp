using System.Net.Http.Json;
using DataAccessLibrary.Models;

namespace MauiBlazorApp.Shared.Services
{
    public interface IDeutschAdjSuffixService
    {
        Task<List<DeutschAdjSuffix>> GetDataAsync();
    }

    public class DeutschAdjSuffixService : IDeutschAdjSuffixService
    {
        private readonly HttpClient _httpClient;

        public DeutschAdjSuffixService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DeutschAdjSuffix>> GetDataAsync()
        {
            var response = await _httpClient.GetAsync("deutschadjsuffix");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<DeutschAdjSuffix>>();
            return data;
        }
    }
}


