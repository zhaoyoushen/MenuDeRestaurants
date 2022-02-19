using MenuDeRestaurants.Models;

namespace MenuDeRestaurants.Database.Contracts
{
    public interface IDishRepository : IRepository<DishModel>
    {
        Task<DishModel> GetDishByIdAsync(Guid id);
    }
}
