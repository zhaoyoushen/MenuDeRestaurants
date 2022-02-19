namespace MenuDeRestaurants.Models.ResponseModels
{
    public class RestaurantResponseModel
    {
        public string? Id { get; set; }

        public IEnumerable<DishResponseModel>? Dishes { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }
    }
}
