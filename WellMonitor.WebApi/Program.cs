using Quartz;
using WellMonitor.Application.DependencyResolver;
using WellMonitor.Infrastructure.DependencyResolver;
using WellMonitor.WebApi.Extensions;
using WellMonitor.WebApi.Jobs;
using WellMonitor.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.RegisterDataAccess(config);
builder.Services.RegisterApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddVersioning(config);
builder.Services.ConfigureLogger(builder.Logging, config);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    q.AddJobAndTrigger<WellDeactivator>();
});
builder.Services.AddQuartzHostedService(
    q => q.WaitForJobsToComplete = true);

var app = builder.Build();

app.InitializeDatabase();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
