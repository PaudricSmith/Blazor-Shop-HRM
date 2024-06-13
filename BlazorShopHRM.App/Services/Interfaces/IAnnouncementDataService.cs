using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.App.Services.Interfaces
{
    public interface IAnnouncementDataService
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncements();
        Task<Announcement> GetAnnouncementById(int announcementId);
        Task<Announcement> AddAnnouncement(Announcement announcement);
        Task UpdateAnnouncement(Announcement announcement);
        Task DeleteAnnouncement(int announcementId);
    }
}
