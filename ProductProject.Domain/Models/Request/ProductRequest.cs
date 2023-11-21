using System.ComponentModel.DataAnnotations;

namespace ProductProject.Domain.Models.Request
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "The 'Name' field is required")]
        [StringLength(100, ErrorMessage = "The 'Name' field has more than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Description' field is required")]
        [StringLength(150, ErrorMessage = "The 'Description' field has more than 150 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The 'Price' field is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The 'Price' field cannot have a negative value.")]
        public decimal Price { get; set; }

        public string? Color { get; set; }

        [Required(ErrorMessage = "The 'CategoryId' field is required")]
        public string CategoryId { get; set; }

    }
}
