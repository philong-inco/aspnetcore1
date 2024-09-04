using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCrud2.DB;
using NetCrud2.Exceptions;
using NetCrud2.Generics;
using NetCrud2.Mapper;
using NetCrud2.Mapper.Impl;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Respository.Impl;
using NetCrud2.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(o => {
//o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
    o.UseOracle(builder.Configuration.GetConnectionString("OracleDbContext"));
});


// Repository // Interface => class abstract => class implement
builder.Services.AddScoped<IRepositoryGenerics<Buyer, string>, BuyerRepository>();
builder.Services.AddScoped<IRepositoryGenerics<Order, string>, OrderRepository>();
builder.Services.AddScoped<IRepositoryGenerics<OrderItem, string>, OrderItemRepository>();

// Mapper // Interface => class implement
builder.Services.AddScoped<IMapperGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse>, BuyerMapper>();
builder.Services.AddScoped<IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse>, OrderMapper>();
builder.Services.AddScoped<IMapperGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse>, OrderItemMapper>();

// Service // Interface => class implement
builder.Services.AddScoped<IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse>, BuyerService>();
builder.Services.AddScoped<IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse>, OrderService>();
builder.Services.AddScoped<IServiceGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse>, OrderItemService>();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new GlobalExceptionFilter());
});

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

app.Run();
