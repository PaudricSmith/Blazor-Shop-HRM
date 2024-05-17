using BlazorShopHRM.App.Models;
using BlazorShopHRM.App.Services;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorShopHRM.App.Components.Widgets
{
    public partial class EmployeeCountWidget
    {
        [Inject]
        IEmployeeDataService? EmployeeDataService { get; set; }

        public int EmployeeCounter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EmployeeCounter = (await EmployeeDataService.GetAllEmployees()).Count();
        }
    }
}
