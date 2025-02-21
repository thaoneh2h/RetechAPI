﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RetechAPI.Models;
using RetechAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// **Cấu hình JWT từ appsettings.json**
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];
var expirationInMinutes = int.Parse(jwtSettings["ExpirationInMinutes"]);

// **Cấu hình JWT Authentication**
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew = TimeSpan.Zero,  // Giới hạn thời gian hết hạn token
        ValidIssuer = issuer,
        ValidAudience = audience
    };
});

// **Thêm các dịch vụ khác vào container**
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers(); // Thêm các controller
builder.Services.AddEndpointsApiExplorer(); // Cấu hình Swagger
builder.Services.AddSwaggerGen(); // Swagger UI

var app = builder.Build();

// **Cấu hình HTTP request pipeline**
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Sử dụng Swagger trong môi trường phát triển
    app.UseSwaggerUI(); // Sử dụng Swagger UI
}

app.UseHttpsRedirection(); // Đảm bảo chỉ sử dụng https

app.UseAuthentication(); // Đảm bảo sử dụng Authentication
app.UseAuthorization();  // Đảm bảo sử dụng Authorization

app.MapControllers(); // Ánh xạ các controller

app.Run();
