using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuDeRestaurants.Database
{
    public class RestaurantRepository : Repository<RestaurantModel>, IRestaurantRepository
    {
        public RestaurantRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<RestaurantModel> GetRestaurantByIdAsync(Guid id)
        {
            var item = await _context.Restaurants
                .Where(r => r.Id == id)
                .Include(x => x.Dishes)
                .AsNoTracking()
                .FirstOrDefaultAsync();
           
            return item;
        }
    }
}
