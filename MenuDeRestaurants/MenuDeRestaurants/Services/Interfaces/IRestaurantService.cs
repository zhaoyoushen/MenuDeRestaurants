using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;

namespace MenuDeRestaurants.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseModel> AddRestaurantAsync(RestaurantModel item);

        Task<IEnumerable<RestaurantResponseModel>> GetAllRestaurantAsync();

        Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id);

        Task DeleteRestaurantAsync(Guid id);

        Task<RestaurantResponseModel> UpdateRestaurantAsync(RestaurantModel item);
    }
}
