using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using PosData.Api.Handler;
using PosData.Api.Implementations;
using PosData.Api.Interfaces;
using PosData.Api.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
   // c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

   // c.OperationFilter<SecurityRequirementsOperationFilter>(true, "BasicAuthentication");

    c.AddSecurityDefinition(
            "BasicAuthentication",
            new OpenApiSecurityScheme()
            {
                Description = "Standard Authorization header using the basic access authentication. Eg: \"Basic dXNlcm5hbWU6cGFzc3dvcmQ=--\" Eg2: \"username:password\"",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
            });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", null);
builder.Services.AddTransient<IProductService<IProduct>, MortorcycleProductServiceManager>();
builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
