using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Retech.Application.Services;
using Retech.DataAccess.Repositories;
using Retech.DataAccess.DataContext;
using Retech.Core;
using Retech.Core.Services;
using Retech.Application.Services.Interfaces;
using Retech.DataAccess.Repositories.Interfaces;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Retech.Service;
using Retech.DataAccess.Repositories.Implementations;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Thêm AutoMapper vào DI container
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Cấu hình AutoMapper sử dụng profile MappingProfile

// **Cấu hình JWT từ appsettings.json**
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
if (string.IsNullOrEmpty(secretKey))
    throw new Exception("JWT SecretKey is missing in appsettings.json");
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

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
        ValidIssuer = issuer,
        ValidAudience = audience,
        ClockSkew = TimeSpan.Zero,
        //RoleClaimType = ClaimTypes.Role
    };
});

// Cấu hình DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductVerificationRepository, ProductVerificationRepository>();
builder.Services.AddScoped<IDeviceVerificationFormRepository, DeviceVerificationFormRepository>();
builder.Services.AddScoped<IProductVerificationService, ProductVerificationService>();
builder.Services.AddScoped<ICategoryService, CategoryService>(); 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITradeUnitService, TradeUnitService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAddressService, UserAddressService>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });// Thêm các controller
builder.Services.AddEndpointsApiExplorer(); // Cấu hình Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Retech API", Version = "v1" });
    c.UseInlineDefinitionsForEnums(); // 👈 Phần quan trọng giúp enum hiển thị dưới dạng string
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Nhập JWT token: Bearer {your token}",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});
// Swagger UI

var app = builder.Build();

// **Cấu hình HTTP request pipeline**
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Sử dụng Swagger trong môi trường phát triển
    app.UseSwaggerUI(); // Sử dụng Swagger UI
}

app.UseHttpsRedirection(); // Đảm bảo chỉ sử dụng https
app.UseAuthentication();  // <- bắt buộc trước Authorization
app.UseAuthorization();

app.MapControllers(); // Ánh xạ các controller
app.Run();
