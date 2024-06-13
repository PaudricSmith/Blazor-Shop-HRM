using BlazorShopHRM.Api.Data;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;


namespace BlazorShopHRM.Api.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AppDbContext _appDbContext;


        public AnnouncementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Announcement>> GetAllAnnouncements()
        {
            return await _appDbContext.Announcements.ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementById(int announcementId)
        {
            return await _appDbContext.Announcements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
        }

        public async Task<Announcement> AddAnnouncement(Announcement announcement)
        {
            var result = await _appDbContext.Announcements.AddAsync(announcement);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Announcement> UpdateAnnouncement(Announcement announcement)
        {
            var result = await _appDbContext.Announcements
                .FirstOrDefaultAsync(a => a.AnnouncementId == announcement.AnnouncementId);

            if (result != null)
            {
                result.Title = announcement.Title;
                result.Content = announcement.Content;
                result.DatePosted = announcement.DatePosted;

                await _appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteAnnouncement(int announcementId)
        {
            var result = await _appDbContext.Announcements
                .FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);

            if (result != null)
            {
                _appDbContext.Announcements.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
