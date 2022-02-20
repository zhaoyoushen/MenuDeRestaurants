# MenuDeRestaurants
## _This is the readme_

This Project is a .NET6 project and you can run it with Visual Studio after setting the Database.
In this readme you can find all details about this project.

## API

- GetAllRestaurants
- GetRestaurantById
- CreateRestaurant
- UpdateRestaurant
- DeleteRestaurant
- GetAllDishes
- GetDishById
- CreateDish
- UpdateDish
- DeleteDish

##### you can find the API documentation when you run the project.
We are using Swashbuckle.AspNetCore [here](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
Swashbuckle will generate API documentation, including a UI to explore and test operations, directly from your routes, controllers and models.

## Tech

- [.Net6] - NET 6 is the fastest full stack web framework.
- [Entity Framework Core] - Entity Framework Core is a modern object-database mapper for . NET. It supports LINQ queries, change tracking, updates, and schema migrations.
- [Automapper] - AutoMapper is an object-object mapper.
- [SQL Server] - Microsoft SQL Server is a relational database management system.

And for all the code you can find on [public repository][menu]
 on GitHub.

**Database schema**

To edit the database model:

1. You need to use the web version of the application or install the desktop version on your PC [*Draw.io*](https://draw.io/).
1. After the changes made, save in .XML and .PNG format

![Database drawio](https://user-images.githubusercontent.com/59487343/154806440-f722a685-0d4e-49c9-aa42-a43be69fd72a.png)

## Installation

### Migrations
Project uses the EF Core with code-first approach. To represent the models we use the C# files and all modifications of data shoud be provided in a form of migrations in C#.

Some useful commands for migrations using PM Console

To set your connection string in "appsettings.json":
```
 "DbContext": {
    "ConnectionString": "Put your connection string here"
  } 
```

To create the migration:

`Add-Migration {descriptive name for migration}`

To run migrations:
`Update-Database`

To check yourself you can run your migrations on your local DB, before pushing to master.

## Development
列出应用程序的不同层
为每个功能在层之间制作流程图

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [menu]: <https://github.com/zhaoyoushen/MenuDeRestaurants>
   [Automapper]: <https://automapper.org/>
   [Entity Framework Core]: <https://docs.microsoft.com/en-us/ef/core/>
   [SQL Server]: <https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15>
   [.Net6]: <https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6>
