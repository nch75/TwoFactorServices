using TwoFactorService.Configurations;
using Microsoft.Extensions.DependencyInjection;
using TwoFactorService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Services.AddSingleton<CodeStorageService>();
builder.Services.Configure<TwoFactorSettings>(builder.Configuration.GetSection("TwoFactorSettings"));
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddScoped<TwoFactorServices>();

// Other builder configurations...

var _ = builder.Build();
