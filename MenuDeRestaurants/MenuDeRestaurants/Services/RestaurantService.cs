using AutoMapper;
using MenuDeRestaurants.Database.Contracts;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;
using MenuDeRestaurants.Services.Interfaces;

namespace MenuDeRestaurants.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(
            IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }


        public async Task<RestaurantResponseModel> AddRestaurantAsync(RestaurantModel item)
        {
            var restaurant = await _restaurantRepository.AddAsync(item);
            return _mapper.Map<RestaurantResponseModel>(restaurant);
        }

        public async Task<IEnumerable<RestaurantResponseModel>> GetAllRestaurantAsync()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            return restaurants.Select(x => _mapper.Map<RestaurantResponseModel>(x));
        }

        public async Task<RestaurantResponseModel> GetRestaurantByIdAsync(Guid id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            return _mapper.Map<RestaurantResponseModel>(restaurant);
        }

        public async Task DeleteRestaurantAsync(Guid id)
        {
            var deleteItem = await _restaurantRepository.GetRestaurantByIdAsync(id);
            CheckForNull(deleteItem);
            await _restaurantRepository.DeleteAsync(deleteItem);

        }

        public async Task<RestaurantResponseModel> UpdateRestaurantAsync(RestaurantModel item)
        {
            var updateItem = await _restaurantRepository.GetRestaurantByIdAsync(item.Id);
            CheckForNull(updateItem);
            var restaurant = await _restaurantRepository.UpdateAsync(item);
            return _mapper.Map<RestaurantResponseModel>(restaurant);
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
