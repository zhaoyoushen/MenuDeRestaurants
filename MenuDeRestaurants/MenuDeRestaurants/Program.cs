using AutoMapper;
using MenuDeRestaurants.Database;
using MenuDeRestaurants.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    //Set your Connection string
    option.UseSqlServer(builder.Configuration["DbContext:ConnectionString"]);
});

// Mapper.
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MenuDeRestaurantsProfile());
    mc.AllowNullCollections = true;
});

var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
