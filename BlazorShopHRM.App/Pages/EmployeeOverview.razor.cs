using BlazorShopHRM.App.Models;
using BlazorShopHRM.App.Services;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        private Employee? _selectedEmployee;
        private string Title = "Employee Overview";

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
