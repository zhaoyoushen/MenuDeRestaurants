using AutoMapper;
using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;
using MenuDeRestaurants.Services.Interfaces;

namespace MenuDeRestaurants.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishService(
            IDishRepository dishRepository,
            IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }


        public async Task<DishResponseModel> AddDishAsync(DishModel item)
        {
            var restaurant = await _dishRepository.AddAsync(item);
            return _mapper.Map<DishResponseModel>(restaurant);
        }

        public async Task<IEnumerable<DishResponseModel>> GetAllDishesAsync()
        {
            var restaurants = await _dishRepository.GetAllAsync();
            return restaurants.Select(x => _mapper.Map<DishResponseModel>(x));
        }

        public async Task<DishResponseModel> GetDishByIdAsync(Guid id)
        {
            var restaurant = await _dishRepository.GetDishByIdAsync(id);
            return _mapper.Map<DishResponseModel>(restaurant);
        }

        public async Task DeleteDishAsync(Guid id)
        {
            var deleteItem = await _dishRepository.GetDishByIdAsync(id);
            CheckForNull(deleteItem);
            await _dishRepository.DeleteAsync(deleteItem);

        }

        public async Task<DishResponseModel> UpdateDishAsync(DishModel item)
        {
            var updateItem = await _dishRepository.GetDishByIdAsync(item.Id);
            CheckForNull(updateItem);
            var restaurant = await _dishRepository.UpdateAsync(item);
            return _mapper.Map<DishResponseModel>(restaurant);
        }

        private void CheckForNull(Object obj)
        {
            if (obj == null)
            {
                throw new Exception("Item is not Found");
            }
        }
    }
}
