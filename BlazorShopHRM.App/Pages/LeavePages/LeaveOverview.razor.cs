using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.LeavePages
{
    public partial class LeaveOverview
    {
        [Inject]
        public ILeaveDataService? LeaveDataService { get; set; }


        private string Title = "Leave Overview";
        private string Description = "Leave overview";

        private List<Leave> Leaves = new List<Leave>();


        protected override async Task OnInitializedAsync()
        {
            Leaves = (await LeaveDataService.GetAllLeaves()).ToList();
        }
    }
}
