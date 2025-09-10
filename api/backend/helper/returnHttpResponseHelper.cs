using backend.Enums;
using backend.response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.helper;

public class returnHttpResponseHelper<T>
{
    public static IActionResult returnHttpResponse(statusCodeEnum statusCode , GenericResponse<T> data)
    {
        if (statusCode.Equals(statusCodeEnum.Ok))
        {
            return new OkObjectResult(data);
        }
        else if(statusCode.Equals(statusCodeEnum.BadRequest))
        {
            return new BadRequestObjectResult(data);
        }else if (statusCode.Equals(statusCodeEnum.Unauthorized))
        {
            return new UnauthorizedObjectResult(data);
        }
        else if (statusCode.Equals(statusCodeEnum.NotFound))
        {
            return new NotFoundObjectResult(data);
        }else if (statusCode.Equals(statusCodeEnum.Forbiden))
        {
            return new ForbidResult();
        }
        else
        {
            return new OkObjectResult(data);
        }
    }
}