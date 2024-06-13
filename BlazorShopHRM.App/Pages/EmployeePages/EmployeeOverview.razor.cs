using BlazorShopHRM.App.Services.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Pages.EmployeePages
{
    public partial class EmployeeOverview
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        private string Title = "Employee Overview";
        private string Description = "employee overview";

        private Employee? _selectedEmployee;
        public List<Employee> Employees { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
