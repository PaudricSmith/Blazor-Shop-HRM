using BlazorShopHRM.App.Models;
using BlazorShopHRM.Shared.Domain;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        private Employee? _selectedEmployee;
        private string Title = "Employee Overview";

        public List<Employee> Employees { get; set; } = default!;


        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees;
        }

        public void ShowQuickViewPopup(Employee selectedEmployee) 
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
