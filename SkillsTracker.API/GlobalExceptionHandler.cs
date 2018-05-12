using SkillsTracker.API.Utilities;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace SkillsTracker.API
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {            
            const string errorMessage = "An unexpected error occured";
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
            new
            {
                Message = errorMessage,
                Exception = context.Exception.Message
            });            
            context.Result = new ResponseMessageResult(response);
            LogHelper.Logger.Error("Exception occurred", context.Exception);
        }
    }
}