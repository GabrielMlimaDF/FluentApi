using FluentMappingApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FluentMappingApi.Controllers
{

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly ContextApp _contextApp;

        public HomeController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }
        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok("Funcionando");
        }
    }
}
