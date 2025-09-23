namespace backend.bootstrapping;

public static class authPolicyConfig
{
    public static void ConfigurePolicyAuth(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("DirectorOnly", policy => policy.RequireRole("Director"));
            options.AddPolicy("CustomerOnly", policy => policy.RequireRole("Customer"));
            options.AddPolicy("CashierOnly", policy => policy.RequireRole("Cashier"));
            options.AddPolicy("ThreaterManagerOnly", policy => policy.RequireRole("Threater Manager"));
            options.AddPolicy("SystemManagerOnly", policy => policy.RequireRole("System Manager"));
            options.AddPolicy("MovieManagerOnly", policy => policy.RequireRole("Movie Manager"));
        });
    }
}