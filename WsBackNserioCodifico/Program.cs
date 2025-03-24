using BacktecnoFactApi.Infraestructura.Util;
using WsBackNserioCodifico.dao;
using WsBackNserioCodifico.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permitir Angular
                  .AllowAnyMethod() // Permitir cualquier método HTTP (GET, POST, etc.)
                  .AllowAnyHeader() // Permitir cualquier encabezado
                  .AllowCredentials(); // Permitir credenciales (si es necesario)
        });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ExecuteQueryBD>();

builder.Services.AddScoped<ICategoriesInter, CategoriesDaoImpl>();
builder.Services.AddScoped<CategoriesDaoImpl>();

builder.Services.AddScoped<ICustomersInter, CustomersDaoImpl>();
builder.Services.AddScoped<CustomersDaoImpl>();

builder.Services.AddScoped<IEmployeesInter, EmployeesDaoImpl>();
builder.Services.AddScoped<EmployeesDaoImpl>();

builder.Services.AddScoped<IOrderDetailsInter, OrderDetailsDaoImpl>();
builder.Services.AddScoped<OrderDetailsDaoImpl>();

builder.Services.AddScoped<IOrdersInter, OrdersDaoImpl>();
builder.Services.AddScoped<OrdersDaoImpl>();

builder.Services.AddScoped<IProductsInter, ProductsDaoImpl>();
builder.Services.AddScoped<ProductsDaoImpl>();

builder.Services.AddScoped<IShippersInter, ShippersDaoImpl>();
builder.Services.AddScoped<ShippersDaoImpl>();

builder.Services.AddScoped<ISuppliersInter, SuppliersDaoImpl>();
builder.Services.AddScoped<SuppliersDaoImpl>();

builder.Services.AddScoped<IpredictionsInter, PredictionsDaoImpl>();
builder.Services.AddScoped<PredictionsDaoImpl>();

var app = builder.Build();

app.UseCors("AllowAngular");

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
