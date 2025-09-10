using backend.middleware;

namespace backend.bootstrapping;

public static class middlewareConfig
{
    public static void middlewareConfigHelper(this WebApplication app)
    {
        app.UseMiddleware<authMiddleware>();
    }
}