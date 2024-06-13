using BlazorShopHRM.App.Services;
using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.LeavePages
{
    public partial class LeaveEdit
    {
        [Inject] public ILeaveDataService? LeaveDataService { get; set; }
        [Inject] public IEmployeeDataService? EmployeeDataService { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }


        [Parameter]
        public int LeaveId { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        private Leave Leave = new Leave();
        private string Message = string.Empty;
        private string StatusClass = string.Empty;
        private bool Saved;


        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (LeaveId == 0)
            {
                Leave = new Leave
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7)
                };
            }
            else
            {
                Leave = await LeaveDataService.GetLeaveDetails(LeaveId);
            }

            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        private async Task HandleValidSubmit()
        {
            Saved = false;

            if (Leave.LeaveId == 0)
            {
                var addedLeave = await LeaveDataService.AddLeave(Leave);
                if (addedLeave != null)
                {
                    StatusClass = "alert-success";
                    Message = "New leave added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new leave. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await LeaveDataService.UpdateLeave(Leave);
                StatusClass = "alert-success";
                Message = "Leave updated successfully.";
                Saved = true;
            }
        }

        private async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        private async Task DeleteLeave()
        {
            await LeaveDataService.DeleteLeave(Leave.LeaveId);

            StatusClass = "alert-success";
            Message = "Deleted Successfully";
            Saved = true;
        }

        private void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/leave-overview");
        }
    }
}
