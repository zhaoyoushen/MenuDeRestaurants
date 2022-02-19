using System.ComponentModel.DataAnnotations;
using MenuDeRestaurants.Models.Enum;

namespace MenuDeRestaurants.Models.RequestModels
{
    public class DishRequestModel
    {
        [Required]
        public string Name { get; set; }

        public Guid RestaurantId { get; set; }

        public string? Image { get; set; }

        public CategoryEnum? Category { get; set; }

        public string? Ingredients { get; set; }

        public int? Quantities { get; set; }
    }
}
