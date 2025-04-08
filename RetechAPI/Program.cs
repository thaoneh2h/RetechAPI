using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Retech.API.Hubs;
using Retech.Application.Services;
using Retech.Application.Services.Interfaces;
using Retech.Core;
using Retech.Core.Services;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories;
using Retech.DataAccess.Repositories.Interfaces;
using Retech.Service;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateSlimBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

// Add services to the container.
// Thêm AutoMapper vào DI container
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Cấu hình AutoMapper sử dụng profile MappingProfile
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
builder.Services.AddScoped<IExchangeRequestService, ExchangeRequestService>();
builder.Services.AddScoped<IExchangeRequestRepository, ExchangeRequestRepository>();


builder.Services.AddSignalR();
builder.Services.AddMemoryCache();

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
});
// Swagger UI

var app = builder.Build();


app.UseHealthChecks("/health");

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

app.MapHub<ChatHub>("/chatHub");

app.Run();
