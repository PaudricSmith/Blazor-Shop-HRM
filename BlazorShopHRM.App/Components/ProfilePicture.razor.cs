using Microsoft.AspNetCore.Components;

namespace BlazorShopHRM.App.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
