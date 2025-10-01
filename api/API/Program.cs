using backend.bootstrapping;
using DataAccess.dbConnection;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.connectToDatabase(builder.Configuration);
// Add JWT Config
builder.Services.AddJwtConfig(builder.Configuration);
// Add DI Config
builder.Services.AddDIConfig();

// Add AesGcmEncryption
var key = Convert.FromBase64String(builder.Configuration["Crypto:Aes256KeyB64"]!);
builder.Services.AddSingleton(new AesGcmEncryption(key));

builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddPolicy("AllowLocalHost3000", policyBuilder =>
{
    policyBuilder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add Policy Config

builder.Services.ConfigurePolicyAuth();

var app = builder.Build();

using (var scoped = app.Services.CreateScope())
{
    var services = scoped.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<threaterManagementDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex) 
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}
app.UseCors("AllowLocalHost3000");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.middlewareConfigHelper();
app.UseAuthorization();
// Config Middleware checker
app.MapControllers();

app.Run();