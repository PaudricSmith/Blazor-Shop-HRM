﻿using BlazorShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorShopHRM.App.Components
{
    public partial class Map
    {
        string elementId = $"map-{Guid.NewGuid():D}";

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public double Zoom { get; set; }

        [Parameter]
        public List<Marker> Markers { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", elementId, Markers);
        }
    }
}
