using BlazorShopHRM.App.Components.Widgets;

namespace BlazorShopHRM.App.Pages
{
    public partial class Home
    {
        private string Title = "Home Page";


        public List<Type> Widgets { get; set; } = new List<Type>()
        {
            typeof(EmployeeCountWidget), typeof(InboxWidget)
        };
    }
}
