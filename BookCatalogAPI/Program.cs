using BookCatalogAPI.Core.Repositories;
using BookCatalogAPI.Infrastructure.Data;
using BookCatalogAPI.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using BookCatalogAPI.Core.Configurations;
using BookCatalogAPI.Core.Services.Contracts;
using BookCatalogAPI.Core.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IBookCatalogRepository, BookCatalogRepository>();
builder.Services.AddScoped<IBookCatalogService, BookCatalogService>();
builder.Services.ConfigurationAutoMapper();

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
