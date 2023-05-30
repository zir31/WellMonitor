using Microsoft.EntityFrameworkCore;
using WellMonitor.Infrastructure;
using WellMonitor.Infrastructure.DependencyResolver;
using WellMonitor.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.RegisterDataAccess(config);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddVersioning(config);
builder.Services.ConfigureLogger(builder.Logging, config);

var app = builder.Build();

app.InitializeDatabase();
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
