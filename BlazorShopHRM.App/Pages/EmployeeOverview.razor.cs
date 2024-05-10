using BlazorShopHRM.App.Models;
using BlazorShopHRM.Shared.Domain;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        private Employee? _selectedEmployee;

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
