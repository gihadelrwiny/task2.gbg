using Microsoft.EntityFrameworkCore;
using task21.context;
using task21.Extensions;
using task21.Interfaces;
using task21.Models;
using task21.Services;
using WebApplication1.Extensions;

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

builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.SeedRolesAndAdminAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllers();


app.Run();
