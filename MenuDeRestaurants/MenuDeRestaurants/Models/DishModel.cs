using MenuDeRestaurants.Models.Enum;

namespace MenuDeRestaurants.Models
{
    public class DishModel
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public RestaurantModel? Restaurant { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public CategoryEnum? Category { get; set; }

        public string? Ingredients { get; set; }

        public int? Quantities { get; set; }
    }
}
