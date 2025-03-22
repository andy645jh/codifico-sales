using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/").AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddDbContext<StoreSampleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SimpleStoreDb"))
);

//inject repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
builder.Services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
builder.Services.AddScoped<IClientOrderRepository, ClientOrderRepository>();

//inject services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();
builder.Services.AddScoped<IProductOrderService, ProductOrderService>();
builder.Services.AddScoped<IClientOrderService, ClientOrderService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseCors(MyAllowSpecificOrigins);
app.Run();
