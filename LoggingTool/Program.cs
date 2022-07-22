using LoggingTool.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoggingToolContext>(options =>
           options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("LocalCs")));
builder.Services.AddIdentity<User, IdentityRole>(o => o.Password = new PasswordOptions
{
    RequireDigit = true,
    RequiredLength = 8,
    RequireLowercase = true,
    RequireUppercase = true,
    RequireNonAlphanumeric = false
}).AddEntityFrameworkStores<LoggingToolContext>();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
