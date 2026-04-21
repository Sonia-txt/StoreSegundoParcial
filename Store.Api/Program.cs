
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Api.Repositories.Interface;
using Store.Api.DataAccess;
using Store.Api.Repositories;
using Store.Api.DataAccess.Interfaces;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductRepository>(); 
builder.Services.AddScoped<IProductRepository>();
builder.Services.AddScoped<IDbContext, IDbContext>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();