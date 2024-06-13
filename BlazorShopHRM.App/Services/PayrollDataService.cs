using Blazored.LocalStorage;
using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;


namespace BlazorShopHRM.App.Services
{
    public class PayrollDataService : IPayrollDataService
    {
        private readonly HttpClient _httpClient;


        public PayrollDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Payroll> AddPayroll(Payroll payroll)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/payroll", payroll);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Payroll>();
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error response: {responseBody}");
                    throw new ApplicationException($"Error adding payroll: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw new ApplicationException("Error adding payroll", ex);
            }
        }

        public async Task UpdatePayroll(int payrollId, Payroll payroll)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/payroll/{payrollId}", payroll);

            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error updating payroll: {responseBody}");
            }
        }

        public async Task DeletePayroll(int payrollId)
        {
            var response = await _httpClient.DeleteAsync($"api/payroll/{payrollId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Error deleting payroll");
            }

        }

        public async Task<IEnumerable<Payroll>> GetAllPayrolls()
        {
            var response = await _httpClient.GetAsync("api/payroll");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Payroll>>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error fetching payrolls: {errorContent}");
            }
        }

        public async Task<Payroll> GetPayrollById(int payrollId)
        {
            return await _httpClient.GetFromJsonAsync<Payroll>($"api/payroll/{payrollId}");
        }

        public async Task<IEnumerable<Payroll>> GetPayrollsByEmployeeId(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Payroll>>(
                await _httpClient.GetStreamAsync($"api/payroll/employee/{employeeId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
