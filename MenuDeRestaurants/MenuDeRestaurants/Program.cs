using AutoMapper;
using MenuDeRestaurants.Database;
using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Mappers;
using MenuDeRestaurants.Services;
using MenuDeRestaurants.Services.Interfaces;
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

//Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();

//Services
builder.Services.AddTransient<IRestaurantService, RestaurantService>();

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
