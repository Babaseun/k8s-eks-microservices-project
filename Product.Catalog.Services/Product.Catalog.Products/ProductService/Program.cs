
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Middlewares;
using ProductService.Repositories;
using ProductService.Services;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Build the connection string from environment variables
Env.Load();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST"); 
var dbPort = Environment.GetEnvironmentVariable("DB_PORT"); 
var dbName = Environment.GetEnvironmentVariable("DB_NAME"); 
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService.Services.ProductService>();


var app = builder.Build();
 
// Use Prometheus middleware
app.UseMetricServer(); 
app.UseHttpMetrics();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
    PreSeeder.Seeder(dbContext, productRepository).Wait();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers(); 
app.Run();
