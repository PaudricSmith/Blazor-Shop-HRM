using BlazorShopHRM.App.Models;
using BlazorShopHRM.App.Services;
using BlazorShopHRM.Shared.Domain;
using BlazorShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        private string Title = "Employee Details";

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee? Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        
            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue) 
            {
                MapMarkers = new List<Marker>
                {
                    new Marker { 
                        Description = $"{Employee.FirstName} {Employee.LastName}",
                        ShowPopup = false,
                        X = Employee.Longitude.Value,
                        Y = Employee.Latitude.Value
                    }
                };
            }
        }
    }
}
