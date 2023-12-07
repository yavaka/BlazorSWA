using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Api;

public class SaveLinkResponse
{
    [CosmosDBOutput(
        databaseName: "blazor-swa",
        collectionName: "linkbundles",
        ConnectionStringSetting = "CosmosDbConnectionString",
        PartitionKey = "{VanityUrl}")]
    public LinkBundle NewLinkBundle { get; set; } = default!;
    public HttpResponseData HttpResponse { get; set; } = default!;
}
