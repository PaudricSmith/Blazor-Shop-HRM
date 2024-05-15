using Blazored.LocalStorage;
using BlazorShopHRM.App;
using BlazorShopHRM.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ApplicationState>();

await builder.Build().RunAsync();
