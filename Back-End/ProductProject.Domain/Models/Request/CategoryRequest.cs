using System.ComponentModel.DataAnnotations;

namespace ProductProject.Domain.Models.Request
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(100, ErrorMessage = "Name has more than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [StringLength(150, ErrorMessage = "Description has more than 150 characters.")]
        public string Description { get; set; }
    }
}
