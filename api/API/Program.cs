using backend.bootstrapping;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.connectToDatabase(builder.Configuration);
// Add JWT Config
builder.Services.AddJwtConfig(builder.Configuration);
// Add DI Config
builder.Services.AddDIConfig();

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