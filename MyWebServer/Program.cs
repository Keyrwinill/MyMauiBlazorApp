using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//+>>20241229
builder.Services.AddDbContext<MypersonaldbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));
//+<<20241229
//+>>20250105
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("https://localhost:7121")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//+<<20250105

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowBlazorApp");      //+20250105

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
