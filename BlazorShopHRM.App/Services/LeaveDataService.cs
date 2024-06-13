using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using System.Text;
using System.Text.Json;


namespace BlazorShopHRM.App.Services
{
    public class LeaveDataService : ILeaveDataService
    {
        private readonly HttpClient _httpClient;


        public LeaveDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Leave> AddLeave(Leave leave)
        {
            var leaveJson = new StringContent(JsonSerializer.Serialize(leave), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/leave", leaveJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Leave>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateLeave(Leave leave)
        {
            var leaveJson = new StringContent(JsonSerializer.Serialize(leave), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/leave", leaveJson);
        }

        public async Task DeleteLeave(int leaveId)
        {
            await _httpClient.DeleteAsync($"api/leave/{leaveId}");
        }

        public async Task<IEnumerable<Leave>> GetAllLeaves()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Leave>>(
                await _httpClient.GetStreamAsync($"api/leave"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return list;
        }

        public async Task<Leave> GetLeaveDetails(int leaveId)
        {
            return await JsonSerializer.DeserializeAsync<Leave>(
                await _httpClient.GetStreamAsync($"api/leave/{leaveId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Leave>> GetLeavesByEmployeeId(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Leave>>(
                await _httpClient.GetStreamAsync($"api/leave/employee/{employeeId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
