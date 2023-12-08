using System.Net;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions;

public class GetLinks
{
    private readonly ILogger _logger;

    public GetLinks(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GetLinks>();
    }

    [Function("GetLinks")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "links/{vanityUrl}")] HttpRequestData req,
        [CosmosDBInput(
            databaseName: "blazor-swa",
            collectionName: "linkbundles",
            ConnectionStringSetting = "CosmosDbConnectionString",
            SqlQuery ="SELECT * FROM c WHERE c.vanityUrl = {vanityUrl}",
            PartitionKey = "{vanityUrl}")] IEnumerable<LinkBundle> linkItem)
    {
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (linkItem.Any())
            {
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(linkItem.Single());
                return response;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return req.CreateResponse(HttpStatusCode.BadRequest);
    }
}
