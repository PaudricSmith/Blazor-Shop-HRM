using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.AnnouncementPages
{
    public partial class AnnouncementEdit
    {
        [Inject] IAnnouncementDataService? AnnouncementDataService { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }

        private string Title = "Add Announcement";
        private readonly string Description = "Announcement Add/Edit page";

        [Parameter]
        public int AnnouncementId { get; set; }

        public Announcement Announcement { get; set; } = new Announcement();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (AnnouncementId == 0)
            {
                // New announcement
                Announcement = new Announcement()
                {
                    DatePosted = DateTime.Now
                };
            }
            else
            {
                Title = "Edit Announcement";

                // Get the announcement with the given ID
                Announcement = await AnnouncementDataService.GetAnnouncementById(AnnouncementId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Announcement.AnnouncementId == 0)
            {
                var addedAnnouncement = await AnnouncementDataService.AddAnnouncement(Announcement);
                if (addedAnnouncement != null)
                {
                    StatusClass = "alert-success"; // Bootstrap class
                    Message = "New announcement added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger"; // Bootstrap class
                    Message = "Something went wrong adding the new announcement. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await AnnouncementDataService.UpdateAnnouncement(Announcement);

                StatusClass = "alert-success"; // Bootstrap class
                Message = "Announcement updated successfully.";
                Saved = true;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger"; // Bootstrap class
            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/announcement-overview");
        }
    }
}
