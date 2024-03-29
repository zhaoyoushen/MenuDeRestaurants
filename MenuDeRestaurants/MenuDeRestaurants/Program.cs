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

//Set your Connection string
builder.Services.AddDbContext<AppDbContext>(option =>
{
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
builder.Services.AddTransient<IDishRepository, DishRepository>();

//Services
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<IDishService, DishService>();

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
