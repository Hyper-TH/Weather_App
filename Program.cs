using Microsoft.EntityFrameworkCore;
using React_ASPNETCore;
using React_ASPNETCore.Data;
using React_ASPNETCore.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader() 
        .AllowAnyMethod());
});

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbContext")));

// Firestore Config
Env.Load("config/.env");


var projectId = Environment.GetEnvironmentVariable("GOOGLE_PROJECT_ID");
var credentialsPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
if (string.IsNullOrEmpty(projectId))
{
    throw new InvalidOperationException("Google Project ID is not set in the environment variables.");
}

builder.Services.AddSingleton(new FirestoreService(projectId));

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware for development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");  // Make sure Swagger is configured to point to the correct endpoint
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
