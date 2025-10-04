

using Microsoft.EntityFrameworkCore;
using Repositories.Data;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Implements;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Ưu tiên lấy từ Environment Variable
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION")
                      ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IGameLevelRepository, GameLevelRepository>();
builder.Services.AddScoped<IResultLevelRepository, ResultLevelRepository>();
builder.Services.AddScoped<IGameProgressRepository, GameProgressRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

//Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGameLevelService, GameLevelService>();
builder.Services.AddScoped<IResultLevelService, ResultLevelService>();
builder.Services.AddScoped<IGameProgressService, GameProgressService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

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
