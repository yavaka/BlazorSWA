using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Layout.Components;

public partial class BundleItem
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public Link Link { get; set; } = default!;

    public async void OpenLink()
    {
        if (string.IsNullOrEmpty(Link.Url) is false)
        {
            await JSRuntime.InvokeVoidAsync("open", Link.Url, "_blank");
        }
    }
}