using MenuDeRestaurants.Models;

namespace MenuDeRestaurants.Database.Contracts
{
    public interface IRestaurantRepository : IRepository<RestaurantModel>
    {
        Task<RestaurantModel> GetRestaurantByIdAsync(Guid id);
    }
}
