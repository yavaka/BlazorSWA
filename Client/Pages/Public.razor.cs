using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages;

public partial class Public
{
    [Inject]
    public HttpClient Http { get; set; } = default!;

    [Parameter]
    public string VanityUrl { get; set; } = string.Empty;

    public LinkBundle CurrentList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetList();
    }

    private async Task GetList()
    {
        CurrentList = await Http.GetFromJsonAsync<LinkBundle>($"api/links/{VanityUrl}") ?? new LinkBundle();
    }
}