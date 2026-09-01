using Asp.Versioning;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order.Data.Automapper;
using Order.Data.Context;
using Order.Data.Services;
using ProjectCommonCode;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OrderDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddAutoMapper(typeof(UserMapping));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
{

    //Default version to use when client does specify one
    options.DefaultApiVersion = new ApiVersion(1, 0);

    options.AssumeDefaultVersionWhenUnspecified = true;

    options.ReportApiVersions = true;

    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),//api/v1/user, //api/v1/user

        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version")
    );
})
.AddApiExplorer(options =>
{

    //Format of api versioing (e.g 'v1', 'v3'
    options.GroupNameFormat = "'v'VVV";

    options.SubstituteApiVersionInUrl = true;


});
//here we can register the swagger configuration options helper we 




builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

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
