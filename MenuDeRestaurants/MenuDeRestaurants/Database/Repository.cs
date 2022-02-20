using System.Net;
using Microsoft.EntityFrameworkCore;

namespace MenuDeRestaurants.Database
{
    public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(TEntity item)
        {
            _context.Attach(item);
            _context.Remove(item);

            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new System.Exception("Delete Failed");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _context.Update(item);

            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new System.Exception("Update Failed");
            }

            return item;
        }
    }
}
