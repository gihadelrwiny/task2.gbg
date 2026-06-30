using Microsoft.AspNetCore.Builder.Extensions;
using task21.Helpers.Mapping;
using task21.Helpers.Middlewares;
using task21.Interfaces.IRepository;
using task21.Interfaces.Iservice;
using task21.Models;
using task21.Repository;
using task21.Services;
using AutoMapper;
using Serilog;

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
builder.Services.AddScoped<IEmailService, EmailService>();

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

    app.UseGlobalExceptionHandler();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

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
