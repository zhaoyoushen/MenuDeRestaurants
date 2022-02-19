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

        public async Task DeleteRestaurantAsync(RestaurantModel item)
        {
            await _restaurantRepository.DeleteAsync(item);
        }

        public async Task<RestaurantResponseModel> UpdateRestaurantAsync(RestaurantModel item)
        {
            var restaurant = await _restaurantRepository.UpdateAsync(item);
            return _mapper.Map<RestaurantResponseModel>(restaurant);
        }
    }
}
