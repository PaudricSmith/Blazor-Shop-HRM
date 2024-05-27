using BlazorShopHRM.App.Components.Widgets;

namespace BlazorShopHRM.App.Pages
{
    public partial class Home
    {
        private string Title = "Home Page";
        private bool isAuthenticated;

        public List<Type> Widgets { get; set; } = new List<Type>()
        {
            typeof(EmployeeCountWidget), typeof(InboxWidget)
        };

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            isAuthenticated = authState.User.Identity.IsAuthenticated;
        }
    }
}
