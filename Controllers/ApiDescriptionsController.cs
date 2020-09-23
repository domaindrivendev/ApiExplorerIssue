using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ApiExplorerIssue.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiDescriptionsController : Controller
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollectionProvider;

        public ApiDescriptionsController(IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider)
        {
            _apiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var apiDescriptions = _apiDescriptionGroupCollectionProvider.ApiDescriptionGroups.Items
                .SelectMany(group => group.Items)
                .Select(apiDescription =>
                    new
                    {
                        relativePath = apiDescription.RelativePath,
                        httpMethod = apiDescription.HttpMethod,
                        parameters = apiDescription.ParameterDescriptions
                            .Select(parameterDescription =>
                                new
                                {
                                    name = parameterDescription.Name,
                                    source = parameterDescription.Source
                                })
                    });

            return new ObjectResult(apiDescriptions);
        }
    }
}
