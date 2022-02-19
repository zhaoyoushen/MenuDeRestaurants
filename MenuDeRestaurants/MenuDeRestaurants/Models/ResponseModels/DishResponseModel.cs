namespace MenuDeRestaurants.Models.ResponseModels
{
    public class DishResponseModel
    {
        public string? Id { get; set; }

        public string? RestaurantId { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Category { get; set; }

        public string? Ingredients { get; set; }

        public int? Quantities { get; set; }
    }
}
