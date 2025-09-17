using backend.Enums;

namespace backend.middleware;

public class authMiddleware
{
    private readonly RequestDelegate _next;

    public authMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ignorePath = new List<string>()
        {
            "/api/v1/Auth/login"
        };
        
        Console.WriteLine(context.Request.Path);
        if (ignorePath.Contains(context.Request.Path))
        {
            await _next(context);
        }
        else
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");
            if (token != null && token.Any())
            {
                if (token[0] == "Bearer")
                {
                    await _next(context);
                }
                else
                {
                    Console.WriteLine("Bearer Token Require");
                    context.Response.StatusCode = (int)statusCodeEnum.Unauthorized;
                }
            } else
            {
                context.Response.StatusCode = (int)statusCodeEnum.Unauthorized;
                Console.WriteLine("Token Require");
            }
            
        }
        
    }
}