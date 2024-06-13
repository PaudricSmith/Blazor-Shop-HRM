using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorShopHRM.App.Components
{
    public partial class PayrollCard
    {
        [Parameter]
        public Payroll Payroll { get; set; } = default!;

        [Parameter]
        public EventCallback<Payroll> PayrollEditClicked { get; set; }

        [Parameter]
        public EventCallback<Payroll> PayrollDeleteClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
    }
}
