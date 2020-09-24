using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerIssue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("get-foo")]
        public DataQueryOptions? Foo([FromQuery] DataQueryOptions? queryOptions)
        {
            return queryOptions;
        }

        public class DataQueryOptions
        {
            /// <summary> Paging settings </summary>
            [FromQuery(Name = "paging")]
            public DataQueryPaging? Paging { get; set; }
        }

        public sealed class DataQueryPaging
        {
            [FromQuery(Name = "top")]
            [Required]
            public int Top { get; set; }

            [FromQuery(Name = "skip")]
            [Required]
            public int Skip { get; set; }

            [FromQuery(Name = "count")]
            public bool? Count { get; set; }
        }
    }
}