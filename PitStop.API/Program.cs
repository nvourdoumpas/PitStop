using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using PitStop.Core;
using PitStop.Core.Helpers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Allowed Cors Origins by config file
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins ?? [])
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Postgres DB
builder.Services.AddDbContextPool<AppDbContext>(opt =>
    opt.UseNpgsql(
        Util.Decrypt(builder.Configuration.GetConnectionString("DefaultConnection")), 
        d => { d.MigrationsHistoryTable("__efmigrationshistory", "core"); })
    .EnableDetailedErrors()
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PitStop API",
        Description = "PitStop Web API for managing operations about your garage",
        Contact = new OpenApiContact
        {
            Name = "Owners",
            Email = "nvourdoumpas@hotmail.com"
        }
    });
});
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PitStop API V1");
    options.IndexStream = () => File.OpenRead("wwwroot/swagger-ui/index.html");
});
app.UseReDoc(options =>
{
    options.DocumentTitle = "PitStop API - Documentation";
    options.SpecUrl = "/swagger/v1/swagger.json";
    options.RoutePrefix = "redoc"; // Access it at /redoc
});

//

//}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();
