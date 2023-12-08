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

    private bool _showNotFoundNotification;

    public LinkBundle CurrentList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetList();
    }

    private async Task GetList()
    {
        var requst = await Http.GetAsync($"api/links/{VanityUrl}");

        if (requst.IsSuccessStatusCode)
        {
            CurrentList = (await requst.Content.ReadFromJsonAsync<LinkBundle>())!;
        }
        else
        {
            _showNotFoundNotification = true;
        }
    }
}