using AutoMapper;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.RequestModels;
using MenuDeRestaurants.Models.ResponseModels;
using MenuDeRestaurants.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuDeRestaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<RestaurantController> _logger;
        private readonly IMapper _mapper;

        public RestaurantController(
            ILogger<RestaurantController> logger,
            IMapper mapper,
            IRestaurantService restaurantService)
        {
            _logger = logger;
            _mapper = mapper;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                var result = await _restaurantService.GetAllRestaurantAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantRequestModel requestModel)
        {
            try
            {
                var restaurant = _mapper.Map<RestaurantModel>(requestModel);
                var result = await _restaurantService.AddRestaurantAsync(restaurant);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}