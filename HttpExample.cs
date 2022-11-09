using System.Threading.Tasks;
using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HotChocolateIsolated
{
	public class HttpExample
	{
		private readonly IGraphQLRequestExecutor graphQlRequestExecutor;

		public HttpExample(IGraphQLRequestExecutor graphQlRequestExecutor)
		{
			this.graphQlRequestExecutor = graphQlRequestExecutor;
		}

		[Function("HttpExample")]
		public async Task<HttpResponseData> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql")] HttpRequestData req,
			ILogger log)
		{
			return await graphQlRequestExecutor.ExecuteAsync(req);
		}
	}
}
