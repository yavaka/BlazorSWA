using System.Collections.Generic;

namespace BlazorApp.Shared
{
    public class LinkBundle
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string VanityUrl { get; set; }
        public string Description { get; set; }

        public List<Link> Links { get; set; }
    }
}
