using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Layout.Components
{
    public partial class DangerNotification
    {
        [Parameter, EditorRequired]
        public string Message { get; set; } = string.Empty;

        protected override Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(Message))
                throw new Exception("Message parameter cannot be null or empty!");

            return base.OnInitializedAsync();
        }
    }
}