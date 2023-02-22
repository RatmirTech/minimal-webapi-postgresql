using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using WebApiPostgresql.Api.Interfaces;
using WebApiPostgresql.Api.Models;
using WebApiPostgresql.Api.Repositories;
using WebApiPostgresql.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();

var connectionString = builder.Configuration["DbNpgsql"];

builder.Services.AddDbContext<EfContext>(opt =>
{
    opt.UseNpgsql(connectionString);
    //opt.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});
builder.Services.AddScoped<IDbContext>(sp => sp.GetRequiredService<EfContext>());

builder.Services.AddScoped<IDbConnection, NpgsqlConnection>(sp =>
{
    var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

app.MapGet("/p", async (EfContext db) => await db.Products.ToListAsync());

app.Run();
