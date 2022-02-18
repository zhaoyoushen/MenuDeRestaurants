namespace MenuDeRestaurants.Models
{
    public class RestaurantModel
    {
        public Guid Id { get; set; }

        public Guid DishId { get; set; }

        public DishModel? Dish { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }
    }
}
