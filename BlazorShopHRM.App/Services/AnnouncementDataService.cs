using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using System.Net.Http.Json;


namespace BlazorShopHRM.App.Services
{
    public class AnnouncementDataService : IAnnouncementDataService
    {
        private readonly HttpClient _httpClient;


        public AnnouncementDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<Announcement>> GetAllAnnouncements()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Announcement>>("api/announcement");
        }

        public async Task<Announcement> GetAnnouncementById(int announcementId)
        {
            return await _httpClient.GetFromJsonAsync<Announcement>($"api/announcement/{announcementId}");
        }

        public async Task<Announcement> AddAnnouncement(Announcement announcement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/announcement", announcement);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Announcement>();
            }
            else
            {
                throw new ApplicationException($"Error adding announcement: {response.ReasonPhrase}");
            }
        }

        public async Task UpdateAnnouncement(Announcement announcement)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/announcement/{announcement.AnnouncementId}", announcement);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error updating announcement: {response.ReasonPhrase}");
            }
        }

        public async Task DeleteAnnouncement(int announcementId)
        {
            var response = await _httpClient.DeleteAsync($"api/announcement/{announcementId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error deleting announcement: {response.ReasonPhrase}");
            }
        }
    }
}
