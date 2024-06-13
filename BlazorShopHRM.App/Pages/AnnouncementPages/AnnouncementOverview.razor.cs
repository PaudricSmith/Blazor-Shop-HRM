using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.AnnouncementPages
{
    public partial class AnnouncementOverview
    {
        [Inject]
        public IAnnouncementDataService? AnnouncementDataService { get; set; }

        private List<Announcement> Announcements { get; set; } = new List<Announcement>();


        protected override async Task OnInitializedAsync()
        {
            Announcements = (await AnnouncementDataService.GetAllAnnouncements()).ToList();
        }
    }
}
