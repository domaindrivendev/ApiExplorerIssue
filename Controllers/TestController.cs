using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerIssue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [Route("foo")]
        [Route("bar/{id}")]
        public IActionResult Get(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
