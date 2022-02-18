using AutoMapper;
using MenuDeRestaurants.Models;
using MenuDeRestaurants.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MenuDeRestaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private static readonly List<RestaurantModel> Summaries = new List<RestaurantModel> 
        {
            new RestaurantModel
            {
                Id = Guid.NewGuid(),
                Name = "test"
            }
        };

        private readonly ILogger<RestaurantController> _logger;
        private readonly IMapper _mapper;

        public RestaurantController(
            ILogger<RestaurantController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRestaurants")]
        public IEnumerable<RestaurantResponseModel> Get()
        {
            try
            {
                return Summaries.Select(x => _mapper.Map<RestaurantResponseModel>(x));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}