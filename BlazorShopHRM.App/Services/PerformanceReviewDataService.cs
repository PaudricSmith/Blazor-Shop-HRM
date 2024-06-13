using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using System.Text;
using System.Text.Json;


namespace BlazorShopHRM.App.Services
{
    public class PerformanceReviewDataService : IPerformanceReviewDataService
    {
        private readonly HttpClient _httpClient;


        public PerformanceReviewDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<PerformanceReview> AddPerformanceReview(PerformanceReview performanceReview)
        {
            var performanceReviewJson = new StringContent(JsonSerializer.Serialize(performanceReview), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/performanceReview", performanceReviewJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<PerformanceReview>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdatePerformanceReview(PerformanceReview performanceReview)
        {
            var performanceReviewJson = new StringContent(JsonSerializer.Serialize(performanceReview), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/performanceReview", performanceReviewJson);
        }

        public async Task DeletePerformanceReview(int performanceReviewId)
        {
            await _httpClient.DeleteAsync($"api/performanceReview/{performanceReviewId}");
        }

        public async Task<IEnumerable<PerformanceReview>> GetAllPerformanceReviews()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<PerformanceReview>>(
                await _httpClient.GetStreamAsync($"api/performanceReview"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return list;
        }

        public async Task<PerformanceReview> GetPerformanceReviewDetails(int performanceReviewId)
        {
            return await JsonSerializer.DeserializeAsync<PerformanceReview>(
                await _httpClient.GetStreamAsync($"api/performanceReview/{performanceReviewId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<PerformanceReview>> GetPerformanceReviewsByEmployeeId(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PerformanceReview>>(
                await _httpClient.GetStreamAsync($"api/performanceReview/employee/{employeeId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
