using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Layout.Components;

public partial class BundleItem
{
    [Parameter]
    public Link Link { get; set; } = default!;

    [Parameter]
    public bool Editable { get; set; } = default!;
}