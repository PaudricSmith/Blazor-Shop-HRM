using BlazorShopHRM.App.Services;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using System.Runtime.CompilerServices;

namespace BlazorShopHRM.App.Pages
{
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService? CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService? JobCategoryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string? EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) 
            {
                // Create new Employee and add some defaults
                Employee = new Employee()
                {
                    CountryId = 1,
                    JobCategoryId = 1,
                    BirthDate = DateTime.Now,
                    JoinedDate = DateTime.Now
                };
            }
            else
            {
                // Get the Employee with given Employee Id
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Employee.EmployeeId == 0) //new
            {
                // Image Adding
                if (selectedFile != null) 
                {
                    var file = selectedFile;    
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();

                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                }

                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success"; // Bootstrap class
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger"; // Bootstrap class
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success"; // Bootstrap class
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        private IBrowserFile selectedFile;

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger"; // Bootstrap class
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success"; // Boostrap class
            Message = "Deleted Successfully";
            Saved = true;
        }

        
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
