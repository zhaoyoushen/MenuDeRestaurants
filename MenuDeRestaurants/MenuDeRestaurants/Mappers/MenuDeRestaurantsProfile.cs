using AutoMapper;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.RequestModels;
using MenuDeRestaurants.Models.ResponseModels;

namespace MenuDeRestaurants.Mappers
{
    public class MenuDeRestaurantsProfile : Profile
    {
        public MenuDeRestaurantsProfile()
        {
            CreateMap<DishRequestModel, DishModel>();
            CreateMap<DishModel, DishResponseModel>();
            CreateMap<RestaurantRequestModel, RestaurantModel>();
            CreateMap<RestaurantModel, RestaurantResponseModel>();
        }
    }
}
