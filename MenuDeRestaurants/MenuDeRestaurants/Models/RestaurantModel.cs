namespace MenuDeRestaurants.Models
{
    public class RestaurantModel
    {
        public Guid Id { get; set; }

        public IEnumerable<DishModel>? Dishes { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }
    }
}
