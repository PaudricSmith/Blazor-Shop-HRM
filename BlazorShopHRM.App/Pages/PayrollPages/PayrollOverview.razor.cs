using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace BlazorShopHRM.App.Pages.PayrollPages
{
    public partial class PayrollOverview
    {
        private string Title = "Payroll Overview";
        private string Description = "Payroll overview";
        private List<Payroll> Payrolls = new List<Payroll>();

        [Inject]
        public IPayrollDataService? PayrollDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Payrolls = (await PayrollDataService.GetAllPayrolls()).ToList();

            // Optional additional frontend ordering
            // Payrolls = Payrolls.OrderBy(p => p.Amount).ToList();
        }

        private void EditPayroll(Payroll payroll)
        {
            NavigationManager.NavigateTo($"/payroll-edit/{payroll.PayrollId}");
        }

        private async Task DeletePayroll(Payroll payroll)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to delete this payroll?");
            if (confirmed)
            {
                await PayrollDataService.DeletePayroll(payroll.PayrollId);
                Payrolls = (await PayrollDataService.GetAllPayrolls()).OrderBy(p => p.Month).ToList();
            }

        }
    }
}
