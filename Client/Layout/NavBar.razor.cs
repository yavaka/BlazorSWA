namespace BlazorApp.Client.Layout;

public partial class NavBar
{
    private bool showMenu;
    private void ToggleMenu()
    {
        showMenu = !showMenu;
        StateHasChanged();
    }
}