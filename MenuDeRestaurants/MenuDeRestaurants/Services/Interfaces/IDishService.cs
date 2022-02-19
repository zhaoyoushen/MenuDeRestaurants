using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;

namespace MenuDeRestaurants.Services.Interfaces
{
    public interface IDishService
    {
        Task<DishResponseModel> AddDishAsync(DishModel item);

        Task<IEnumerable<DishResponseModel>> GetAllDishesAsync();

        Task<DishResponseModel> GetDishByIdAsync(Guid id);

        Task DeleteDishAsync(Guid id);

        Task<DishResponseModel> UpdateDishAsync(DishModel item);
    }
}
