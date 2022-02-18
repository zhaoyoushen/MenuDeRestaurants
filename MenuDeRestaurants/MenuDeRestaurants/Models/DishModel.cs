namespace MenuDeRestaurants.Models
{
    public class DishModel
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public RestaurantModel? Restaurant { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Category { get; set; }

        public string? Ingredients { get; set; }

        public string? Quantities { get; set; }
    }
}
