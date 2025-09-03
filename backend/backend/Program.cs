using backend.bootstrapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.connectToDatabase(builder.Configuration);
// Add JWT Config
builder.Services.AddJwtConfig(builder.Configuration);
// Add DI Config
builder.Services.AddDIConfig();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();