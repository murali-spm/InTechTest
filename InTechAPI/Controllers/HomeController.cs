using Microsoft.AspNetCore.Mvc;
using InTechService.Interfaces;

namespace InTechAPI.Controllers
{
    [Route("api/v{version.apiVersion}/")]
    public class HomeController() : BaseController
    {
        [HttpGet]
        [Route("")]
        public string StartAPI()
        {
            return "API Started...";
        }

        [HttpGet]
        [Route("version")]
        public string Version()
        {
            return "API 1.0";
        }
    }
}
