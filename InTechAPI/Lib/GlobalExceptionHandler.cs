using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InTechCommon.DTO;
using InTechCommon.Exceptions;
using InTechCommon.Constants;

namespace InTechAPI.Lib
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            InTechException nex = InTechErrorHandler.HandleError(exception);
            ResponseDto response = new ResponseDto();
            response.Status = "Fail";
            response.Message = "Something went processing, please try agian.";
            if (nex != null)
            {   
                response.StatusCode = nex.StatusCode;   
                response.Message = nex.StatusCode == HttpStatusCodes.INTERNAL_SERVER_ERROR? "Something went wront while processing, please try again." : nex.CustomMessage??"";
            }

            httpContext.Response.StatusCode = response.StatusCode;

            await httpContext.Response
             .WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
