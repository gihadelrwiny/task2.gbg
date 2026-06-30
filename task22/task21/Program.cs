using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
using Serilog;
using task21.EventArguments;
using task21.Helpers.Data;
using task21.Helpers.Mapping;
using task21.Helpers.Middlewares;
using task21.Interfaces;
using task21.Interfaces.IRepository;
using task21.Interfaces.Iservice;
using task21.Models;
using task21.Repository;
using task21.Services;

var builder = WebApplication.CreateBuilder(args);
//serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
//clear consol from log
builder.Logging.ClearProviders();
// add serilog
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
//DependencyInjection
builder.Services.AddScoped<IstudentService, StudentService>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<EmailNotificationService>();
builder.Services.AddSingleton<LoggerSubscriber>();
builder.Services.AddSingleton<IEventBus, EventBus>();


//configuration
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("PaginationOptions"));
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailOptions"));

try
{
    Log.Information("Application Starting");

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    var bus = app.Services.GetRequiredService<IEventBus>();

    var email = app.Services.GetRequiredService<EmailNotificationService>();

    var logger = app.Services.GetRequiredService<LoggerSubscriber>();

    bus.Subscribe<StudentRegisteredEventArgs>(email.OnStudentRegistered);

    bus.Subscribe<StudentRegisteredEventArgs>(logger.OnStudentRegistered);
    app.UseGlobalExceptionHandler();
    app.UseRequestTiming();
    app.UseRateLimiting();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        Log.Information("API ready");

        if (!StudentData.Students.Any())
        {
            StudentData.Students.AddRange(new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Ali",
                Email = "ahmed@example.com",
                Age = 20,
                Grade = 85
            },
            new Student
            {
                Id = 2,
                FirstName = "Sara",
                LastName = "Mohamed",
                Email = "sara@example.com",
                Age = 21,
                Grade = 90
            }
        });

            Log.Information("Initial student data seeded.");
        }
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
