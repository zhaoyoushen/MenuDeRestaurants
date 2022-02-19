using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuDeRestaurants.Database
{
    public class DishRepository : Repository<DishModel>, IDishRepository
    {
        public DishRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<DishModel> GetDishByIdAsync(Guid id)
        {
            var item = await _context.Dish
                .Where(r => r.Id == id)
                .Include(x => x.Restaurant)
                .AsNoTracking()
                .FirstOrDefaultAsync();
           
            return item;
        }
    }
}
