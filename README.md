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

> For Example:
> - If you want to add a new restaurant you can call the "GetAllRestaurants" API,
> - If you want to show all dishes for a restaurant, you can call the "GetRestaurantById"

##### you can find the API documentation when you run the project.
We are using Swashbuckle.AspNetCore [here](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
Swashbuckle will generate API documentation, including a UI to explore and test operations, directly from your routes, controllers and models.

- Click on try it out, you can test the api directly from the browser


![image](https://user-images.githubusercontent.com/59487343/154852113-ab4e9920-758f-44d5-92a8-43a54e6a2ac0.png)
![image](https://user-images.githubusercontent.com/59487343/154852130-a8b6e38c-be57-4195-9b66-5b84ee6c207f.png)

>Also you can find the OAS yaml file in the Repo, and for seeing the documentation you can copy the content paste to https://editor.swagger.io/

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

## Architecture
### Structure
- We are using Layered architecture, if you need more info you can find [here](https://www.oreilly.com/library/view/software-architecture-patterns/9781491971437/ch01.html)
![sapr_0101](https://user-images.githubusercontent.com/59487343/154843731-ce8af317-b62f-4dd2-830e-f48f5ca71e51.png)


Also we are using Repository Pattern(Repository per Entity)
#### Pros:
- Application logic is decoupled from data access details. Only the repository classes should be rewritten when there is a need to switch the data source.
- Custom queries are only found in repository classes. Different parts of the application logic can reuse them. Whenever a new requirement arises, such as filtering by an additional property, the single location needs to be updated.
#### Cons:
- The repository can grow significantly in size if there are a lot of logic associated with an entity. If the repository gets large, it is likely that many dependencies will be injected into the constructor. The more there are, the more difficult it will be to unit test the repository code.
- Read and write queries are part of the same repository class, so reads cannot be scaled out separately from writes.

![Untitled Diagram drawio](https://user-images.githubusercontent.com/59487343/154845455-88fceafb-d1d5-44a0-8968-8dba3311bb63.png)

### Architecture characteristics

#### Overall agility
- Rating: Low
- Analysis: Overall agility is the ability to respond quickly to a constantly changing environment. While change can be isolated through the layers of isolation feature of this pattern, it is still cumbersome and time-consuming to make changes in this architecture pattern because of the monolithic nature of most implementations as well as the tight coupling of components usually found with this pattern.

#### Ease of deployment
- Rating: Low
- Analysis: It must be deployed as a singular unit thus a change to a particular layer means the whole system must be redeployed.
#### Testability
- Rating: High
- Analysis: It is easy to test as components belong to specific layers. As such, they can be tested separately.
#### Performance
- Rating: Low
- Analysis: The larger is it, the more resources it requires for requests to go through multiple layers and thus will cause performance issues.
#### Scalability
- Rating: Low
- Analysis: Although changes can be done to a particular layer, it is not easy because the application is a singular unit. Also, the coupling between layers tends to make it harder. This also makes it difficult to scale.
#### Ease of development
- Rating: High
- Analysis: It is simple and easy to implement because naturally, most applications work in layers.
### Architecture decisions
- Layers of isolation: Each of the layers in the architecture is marked as being closed. This is a very important concept in the layered architecture pattern. A closed layer means that as a request moves from layer to layer.

- Why? If you allow the presentation layer direct access to the persistence layer, then changes made to SQL within the persistence layer would impact both the business layer and the presentation layer, thereby producing a very tightly coupled application with lots of interdependencies between components. This type of architecture then becomes very hard and expensive to change. 

## Function Flow
#### Restaurant
- GetAllRestaurants

![Items drawio (5)](https://user-images.githubusercontent.com/59487343/154841629-873de546-8e0f-48f6-bc7f-6955acdb5827.png)

- GetRestaurantById

![Items drawio (8)](https://user-images.githubusercontent.com/59487343/154841644-fdb2144f-9ecf-47c2-9a53-ca06f3876bfb.png)

- CreateRestaurant

![Items drawio (9)](https://user-images.githubusercontent.com/59487343/154841664-1d319add-6d86-43c0-b29f-79a9ac34be6c.png)

- UpdateRestaurant

![Items drawio (4)](https://user-images.githubusercontent.com/59487343/154841684-3426b66a-2a05-42b0-926d-3a91b57f02e8.png)

- DeleteRestaurant

![Items drawio](https://user-images.githubusercontent.com/59487343/154841699-a21773e2-8de8-4758-9624-eb03d70dd617.png)


#### Dish
- GetAllDishes

![Items drawio (6)](https://user-images.githubusercontent.com/59487343/154841759-9306c72e-b50b-420a-8447-a58dc78d5fba.png)

- GetDishById

![Items drawio (7)](https://user-images.githubusercontent.com/59487343/154841764-8f3acab8-9407-4c4e-bdf7-14ec9ffb7fd2.png)

- CreateDish

![Items drawio (2)](https://user-images.githubusercontent.com/59487343/154841745-1837e88f-b0c5-4385-a389-de7e65437c93.png)

- UpdateDish

![Items drawio (3)](https://user-images.githubusercontent.com/59487343/154841749-80c11a6f-0c76-4f90-8bc7-4350706a6e66.png)

- DeleteDish

![Items drawio (1)](https://user-images.githubusercontent.com/59487343/154841730-27466718-a76d-484f-a9c7-f0353afd3f84.png)


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [menu]: <https://github.com/zhaoyoushen/MenuDeRestaurants>
   [Automapper]: <https://automapper.org/>
   [Entity Framework Core]: <https://docs.microsoft.com/en-us/ef/core/>
   [SQL Server]: <https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15>
   [.Net6]: <https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6>
