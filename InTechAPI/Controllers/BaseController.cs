using Microsoft.AspNetCore.Mvc;
using InTechCommon.Constants;
using InTechCommon.DTO;

namespace InTechAPI.Controllers
{
    [ApiController]
    [Asp.Versioning.ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected ResponseDto ReturnResponse(object result)

        {
            ResponseDto? response = null;
            if (result != null)
            {
                response = new ResponseDto(HttpStatusCodes.OK, Messages.SUCCESS, result);
            }
            else
            {
                response = new ResponseDto(HttpStatusCodes.NO_CONTENT, Messages.SUCCESS, result);
            }

            return response;
        }
    }
}
