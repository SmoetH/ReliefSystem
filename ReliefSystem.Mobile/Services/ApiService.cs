using System.Net.Http.Json;
using System.Text.Json;
using ReliefSystem.Mobile.Models;

namespace ReliefSystem.Mobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7150"; // Update with your actual API URL or Azure App Service URL

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<List<ReliefProject>> GetReliefProjectsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/ReliefProjects");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ReliefProject>>() ?? new();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching projects: {ex.Message}");
            }
            return new List<ReliefProject>();
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            try
            {
                var loginData = new { Email = email, Password = password };
                var response = await _httpClient.PostAsJsonAsync("/api/Auth/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return result?.Token; // Returns your JWT token
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
            return null;
        }
    }
}