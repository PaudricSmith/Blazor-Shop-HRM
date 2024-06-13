using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorShopHRM.App.Pages.PerformanceReviewPages
{
    public partial class PerformanceReviewOverview
    {
        [Inject]
        public IPerformanceReviewDataService PerformanceReviewDataService { get; set; }


        private string Title = "Performance Review Overview";
        private string Description = "Performance review overview";

        private List<PerformanceReview> PerformanceReviews = new List<PerformanceReview>();


        protected override async Task OnInitializedAsync()
        {
            PerformanceReviews = (await PerformanceReviewDataService.GetAllPerformanceReviews()).ToList();
        }
    }
}
