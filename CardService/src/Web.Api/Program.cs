using Application;
using Application.Abstractions.Mapping;
using AutoMapper;
using HealthChecks.UI.Client;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ApplicationMapping());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowCors",
        builder =>
        {
            builder.AllowAnyOrigin().WithMethods(
                       HttpMethod.Get.Method,
                       HttpMethod.Put.Method,
                       HttpMethod.Post.Method,
                       HttpMethod.Delete.Method).AllowAnyHeader();
        });
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
