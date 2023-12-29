using ProductProject.Domain.Models.Response;

namespace ProductProject.Test.Mocks
{
    public class CategoryMock
    {
        public static List<Category> LstCategories => new() 
        {
            new Category{Id = "6561136cd4369dfea8c23744", Name = "Category 1", Description = "Description Category 1" },
            new Category{Id = "656400412a0aa676d76b470d", Name = "Category 2", Description = "Description Category 2" },
            new Category{Id = "656400482a0aa676d76b470e", Name = "Category 3", Description = "Description Category 3" },
            new Category{Id = "6564ac6ef9361e5ebdadf589", Name = "Category 4", Description = "Description Category 4" },
            new Category{Id = "65874b197561e4f287442c1c", Name = "Category 5", Description = "Description Category 5" },
        };
    }
}
