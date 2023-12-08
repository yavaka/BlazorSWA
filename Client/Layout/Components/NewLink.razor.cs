using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Client.Layout.Components
{
    public partial class NewLink
    {
        public string NewLinkUrl { get; set; } = default!;
        private bool IsInvalidUrl;

        private void OnInput()
        {

        }

        private void AddNewLink(KeyboardEventArgs e)
        {
            if (string.IsNullOrEmpty(NewLinkUrl))
            {
                IsInvalidUrl = true;
                return;
            }

            if (e.Key is "Enter")
            {
                if (Uri.TryCreate(NewLinkUrl, UriKind.Absolute, out Uri? uri)
                    && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    IsInvalidUrl = false;

                    Console.WriteLine(uri.ToString());
                    // TODO: Add the link to the link bundle list

                    NewLinkUrl = string.Empty;
                }
                else
                {
                    IsInvalidUrl = true;
                }
            }
        }
    }
}