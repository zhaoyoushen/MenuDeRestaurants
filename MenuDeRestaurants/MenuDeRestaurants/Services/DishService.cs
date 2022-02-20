using AutoMapper;
using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Exception;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;
using MenuDeRestaurants.Services.Interfaces;

namespace MenuDeRestaurants.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public DishService(
            IDishRepository dishRepository, 
            IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }


        public async Task<DishResponseModel> AddDishAsync(DishModel item)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(item.RestaurantId);
            CheckForNull(restaurant, nameof(RestaurantModel));
            var dish = await _dishRepository.AddAsync(item);
            return _mapper.Map<DishResponseModel>(dish);
        }

        public async Task<IEnumerable<DishResponseModel>> GetAllDishesAsync()
        {
            var dishes = await _dishRepository.GetAllAsync();
            return dishes.Select(x => _mapper.Map<DishResponseModel>(x));
        }

        public async Task<DishResponseModel> GetDishByIdAsync(Guid id)
        {
            var dish = await _dishRepository.GetDishByIdAsync(id);
            return _mapper.Map<DishResponseModel>(dish);
        }

        public async Task DeleteDishAsync(Guid id)
        {
            var dish = await _dishRepository.GetDishByIdAsync(id);
            CheckForNull(dish, nameof(DishModel));
            await _dishRepository.DeleteAsync(dish);

        }

        public async Task<DishResponseModel> UpdateDishAsync(DishModel item)
        {
            var updateItem = await _dishRepository.GetDishByIdAsync(item.Id);
            CheckForNull(updateItem, nameof(DishModel));
            var dish = await _dishRepository.UpdateAsync(item);
            return _mapper.Map<DishResponseModel>(dish);
        }

        private void CheckForNull(Object obj, string name)
        {
            if (obj == null)
            {
                throw new MyException(name);
            }
        }
    }
}
