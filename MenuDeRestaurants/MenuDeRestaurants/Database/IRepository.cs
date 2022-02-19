namespace MenuDeRestaurants.Database
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity item);

        Task DeleteAsync(TEntity item);

        Task<TEntity> UpdateAsync(TEntity item);
    }
}
