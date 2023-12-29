using System.ComponentModel.DataAnnotations;

namespace ProductProject.Domain.Models.Request
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(100, ErrorMessage = "Name has more than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [StringLength(150, ErrorMessage = "Description has more than 150 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price cannot be null")]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot have a negative value.")]
        public decimal Price { get; set; }

        public string? Color { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string CategoryId { get; set; }

    }
}
