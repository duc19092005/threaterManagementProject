using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.response;

public class HttpRequestResponse<T>
{
    public static IActionResult checkingResponse(int statusCode , GenericResponse<T> response)
    {
        if (statusCode.Equals(StatusCodes.Status201Created))
        {
            return new CreatedResult("http://localhost:5000/api/v1/Auth/login", response);
        }else if (statusCode.Equals(StatusCodes.Status200OK))
        {
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }else if (statusCode.Equals(StatusCodes.Status500InternalServerError))
        {
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }else if (statusCode.Equals(StatusCodes.Status404NotFound))
        {
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }else if (statusCode.Equals(StatusCodes.Status409Conflict))
        {
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
        else
        {
            return new BadRequestObjectResult(response);
        }
    }
}