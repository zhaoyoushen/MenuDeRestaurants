using System.ComponentModel.DataAnnotations;

namespace MenuDeRestaurants.Models.RequestModels
{
    public class RestaurantRequestModel
    {
        public Guid DishId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Image { get; set; }
    }
}
