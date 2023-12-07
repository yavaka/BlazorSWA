using System.Net;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions
{
    public class SaveLinks
    {
        private readonly ILogger _logger;

        public SaveLinks(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SaveLinks>();
        }

        [Function("SaveLinks")]
        public async Task<SaveLinkResponse> Run([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "links/savelinks")] HttpRequestData req,
            FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var linkBundle = await req.ReadFromJsonAsync<LinkBundle>();

            if (linkBundle is null)
                return default!;

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to Azure Functions!");

            return new SaveLinkResponse
            {
                NewLinkBundle = linkBundle,
                HttpResponse = response
            };
        }
    }
}
