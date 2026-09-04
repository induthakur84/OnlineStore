using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order.Data.Automapper;
using Order.Data.Context;
using Order.Data.Services;
using ProjectCommonCode;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Services

builder.Services.RegisterServices(typeof(UserService).Assembly.FullName);


// AutoMapper
builder.Services.AddAutoMapper(typeof(UserMapping));

// Controllers
builder.Services.AddControllers();

// API Explorer
builder.Services.AddEndpointsApiExplorer();


// API Versioning
builder.Services.AddApiVersioning(options =>
{
    // Default API version
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // Use v1 if client doesn't specify version
    options.AssumeDefaultVersionWhenUnspecified = true;

    // Return supported/deprecated versions in response headers
    options.ReportApiVersions = true;

    // Support multiple ways of specifying API version
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version")
    );
})
.AddApiExplorer(options =>
{
    // v1, v2, v3
    options.GroupNameFormat = "'v'VVV";

    // Replace {version} in URL with actual version
    options.SubstituteApiVersionInUrl = true;
});


// Swagger
builder.Services.AddSwaggerGen();

// Register Swagger configuration
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


var app = builder.Build();


// Swagger
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    var provider =
        app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"Order API {description.GroupName.ToUpperInvariant()}");
    }
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();