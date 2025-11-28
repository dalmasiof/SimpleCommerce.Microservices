using Microsoft.EntityFrameworkCore;
using Purchase.Application.Interfaces;
using Purchase.Application.Map;
using Purchase.Application.Service;
using Purchase.Infra.Context;
using Purchase.Infra.Interfaces;
using Purchase.Infra.Repositories;
using Purchase.WEB.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PurchaseContext>(options =>
    options.UseInMemoryDatabase("PurchaseDb"));

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseMapper, PurchaseMapper>();
builder.Services.AddScoped<IPurchaseWebMapper, PurchaseWebMapper>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
