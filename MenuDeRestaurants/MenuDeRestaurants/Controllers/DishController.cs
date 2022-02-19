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
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly ILogger<DishController> _logger;
        private readonly IMapper _mapper;

        public DishController(
            ILogger<DishController> logger,
            IMapper mapper,
            IDishService dishService)
        {
            _logger = logger;
            _mapper = mapper;
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            try
            {
                var result = await _dishService.GetAllDishesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}", Name = "GetDishById")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
            try
            {
                var result = await _dishService.GetDishByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] DishRequestModel requestModel)
        {
            try
            {
                var dish = _mapper.Map<DishModel>(requestModel);
                var result = await _dishService.AddDishAsync(dish);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}", Name = "UpdateDish")]
        public async Task<IActionResult> UpdateDish([FromBody] DishRequestModel requestModel, Guid id)
        {
            try
            {
                var dish = _mapper.Map<DishModel>(requestModel);
                dish.Id = id;
                var result = await _dishService.UpdateDishAsync(dish);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}", Name = "DeleteDish")]
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            try
            {
                await _dishService.DeleteDishAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}