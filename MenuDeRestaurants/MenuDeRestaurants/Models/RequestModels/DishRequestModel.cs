using System.ComponentModel.DataAnnotations;

namespace MenuDeRestaurants.Models.RequestModels
{
    public class DishRequestModel
    {
        [Required]
        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Category { get; set; }

        public string? Ingredients { get; set; }

        public string? Quantities { get; set; }
    }
}
