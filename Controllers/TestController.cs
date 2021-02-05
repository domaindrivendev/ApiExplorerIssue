using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerIssue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Get1([FromQuery]CustomParams queryParams)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]")]
        public IActionResult Get2([FromHeader]CustomParams headerParams)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomParams
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
}
