using FluentValidation;
using FluentValidation.AspNetCore;
using PizzaRestaurant.API.Infrastructure.Extensions;
using PizzaRestaurant.API.Infrastructure.Mappings;
using PizzaRestaurant.API.Infrastructure.Middlewares;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pizza Restaurant Api",
        Description = "Api to manage Pizza Customers and Orders",
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);

    option.IncludeXmlComments(xmlPath);
});
builder.Services.AddServices();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.RegisterMaps();

var app = builder.Build();

app.UseGlobalExceptionHandling(); 
app.UserRequestResponseMiddleware(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRequestCulture();

app.UseAuthorization();

app.MapControllers();

app.Run();


