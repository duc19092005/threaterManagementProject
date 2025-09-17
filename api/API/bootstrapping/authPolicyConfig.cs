namespace backend.bootstrapping;

public static class authPolicyConfig
{
    public static void ConfigurePolicyAuth(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        });
    }
}