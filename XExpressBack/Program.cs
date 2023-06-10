using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XExpressBack._2.Models.Abstractions;
using XExpressBack._3.Infrastructure.Context;
using XExpressBack._3.Infrastructure.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

// configure DI for application services
builder.Services.AddScoped<IClienteDAO, ClienteDAO>();
builder.Services.AddScoped<IDireccionDAO, DireccionDAO>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options =>
{
    //options.WithOrigins("http://localhost:3000");
    //options.WithOrigins("http://l72.30.3.60:81");
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();

});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
