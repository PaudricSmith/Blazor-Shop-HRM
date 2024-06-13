using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace BlazorShopHRM.App.Pages.PayrollPages
{
    public partial class PayrollEdit
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPayrollDataService PayrollDataService { get; set; }
        [Inject] IEmployeeDataService EmployeeDataService { get; set; }


        private string Title = "Add Payroll";
        private readonly string Description = "Payroll Add/Edit page";

        [Parameter] 
        public int PayrollId { get; set; }

        public Payroll Payroll { get; set; } = new Payroll();
        public List<Employee> Employees { get; set; } = new List<Employee>();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (PayrollId == 0)
            {
                // Create new Employee and add some defaults
                Payroll = new Payroll()
                {
                    Month = new DateTime(DateTime.Now.Year, 1, 1), // Set to the first date of the current year
                    Amount = 0
                };
            }
            else
            {
                Title = "Edit Payroll";

                // Get the Payroll with given Payroll Id
                Payroll = await PayrollDataService.GetPayrollById(PayrollId);
            }

            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Payroll.PayrollId == 0)
            {
                var addedPayroll = await PayrollDataService.AddPayroll(Payroll);
                if (addedPayroll != null)
                {
                    StatusClass = "alert-success"; // Bootstrap class
                    Message = "New Payroll added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger"; // Bootstrap class
                    Message = "Something went wrong adding the new Payroll. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await PayrollDataService.UpdatePayroll(Payroll.PayrollId, Payroll);

                StatusClass = "alert-success"; // Bootstrap class
                Message = "Payroll updated successfully.";
                Saved = true;
            }

            NavigateToOverview();
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger"; // Bootstrap class
            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/payroll-overview");
        }
    }
}
