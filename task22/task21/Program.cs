using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using task21.context;
using task21.Interfaces;
using task21.Models;
using task21.Services;
using task21.Shared.Extensions;
using task21.Shared.Handlers;
using task21.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FinalJwtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configure JwtOptions from appsettings.json
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JWT"));

//dependency injection
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
//extensins
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddIdentityConfiguration();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCustomAuthorization();
builder.Services.AddSwaggerGen();
//register the handler
builder.Services.AddSingleton<IAuthorizationHandler,MinExperienceHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, UserProfileHandler>();
// i implemented policy in book controller and profile controller
//cors
builder.Services.AddCors(options =>
{
    // Development: allow everything
    options.AddPolicy("Development", p => p
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
    // Production: specific origin only
    options.AddPolicy("Production", p => p
    .WithOrigins("https://yourfrontend.com",
    "https://admin.yourfrontend.com")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .WithHeaders("Authorization", "Content-Type")
    .AllowCredentials());
});


var app = builder.Build();

await app.SeedRolesAndAdminAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//cors
var policyName = app.Environment.IsDevelopment() ? "Development" : "Production";
app.UseCors(policyName);
app.UseHttpsRedirection();
app.UseRouting();

//middleware
app.UseRateLimiting();


app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllers();


app.Run();
