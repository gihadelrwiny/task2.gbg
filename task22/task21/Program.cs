using Microsoft.AspNetCore.Builder.Extensions;
using task21.Interfaces.IRepository;
using task21.Interfaces.Iservice;
using task21.Models;
using task21.Repository;
using task21.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DependencyInjection
builder.Services.AddScoped<IstudentService, StudentService>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();

//configuration
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("PaginationOptions"));
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailOptions"));
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
