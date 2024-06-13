using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.PerformanceReviewPages
{
    public partial class PerformanceReviewEdit
    {
        [Inject]
        public IPerformanceReviewDataService PerformanceReviewDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        private string Title = "Add Performance Review";
        private readonly string Description = "Performance review Add/Edit page";

        [Parameter]
        public int PerformanceReviewId { get; set; }

        private PerformanceReview PerformanceReview = new PerformanceReview();

        private string Message = string.Empty;
        private string StatusClass = string.Empty;
        private bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (PerformanceReviewId == 0)
            {
                PerformanceReview = new PerformanceReview
                {
                    ReviewDate = DateTime.Now
                };
            }
            else
            {
                Title = "Èdit Performance Review";

                PerformanceReview = await PerformanceReviewDataService.GetPerformanceReviewById(PerformanceReviewId);
            }
        }

        private async Task HandleValidSubmit()
        {
            Saved = false;

            if (PerformanceReview.PerformanceReviewId == 0)
            {
                var addedPerformanceReview = await PerformanceReviewDataService.AddPerformanceReview(PerformanceReview);
                if (addedPerformanceReview != null)
                {
                    StatusClass = "alert-success";
                    Message = "New performance review added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new performance review. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await PerformanceReviewDataService.UpdatePerformanceReview(PerformanceReview);
                StatusClass = "alert-success";
                Message = "Performance review updated successfully.";
                Saved = true;
            }
        }

        private async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        private async Task DeletePerformanceReview()
        {
            await PerformanceReviewDataService.DeletePerformanceReview(PerformanceReview.PerformanceReviewId);

            StatusClass = "alert-success";
            Message = "Deleted Successfully";
            Saved = true;
        }

        private void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/performance-review-overview");
        }
    }
}
