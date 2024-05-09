using BlazorShopHRM.App.Models;
using BlazorShopHRM.Shared.Domain;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees;
        }
    }
}
