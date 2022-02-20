using AutoMapper;
using MenuDeRestaurants.Exception;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.RequestModels;
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

        [HttpGet(Name = "GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                var result = await _restaurantService.GetAllRestaurantAsync();

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetRestaurantById")]
        public async Task<IActionResult> GetRestaurantById(Guid id)
        {
            try
            {
                var result = await _restaurantService.GetRestaurantByIdAsync(id);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantRequestModel requestModel)
        {
            try
            {
                var restaurant = _mapper.Map<RestaurantModel>(requestModel);
                var result = await _restaurantService.AddRestaurantAsync(restaurant);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantRequestModel requestModel, Guid id)
        {
            try
            {
                var restaurant = _mapper.Map<RestaurantModel>(requestModel);
                restaurant.Id = id;
                var result = await _restaurantService.UpdateRestaurantAsync(restaurant);
                return Ok(result);
            }
            catch (MyException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteRestaurant")]
        public async Task<IActionResult> DeleteRestaurant(Guid id)
        {
            try
            {
                await _restaurantService.DeleteRestaurantAsync(id);

                return NoContent();
            }
            catch (MyException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}