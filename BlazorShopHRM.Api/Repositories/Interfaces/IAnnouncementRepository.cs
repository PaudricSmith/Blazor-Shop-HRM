using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncements();
        Task<Announcement> GetAnnouncementById(int announcementId);
        Task<Announcement> AddAnnouncement(Announcement announcement);
        Task<Announcement> UpdateAnnouncement(Announcement announcement);
        Task DeleteAnnouncement(int announcementId);
    }
}
