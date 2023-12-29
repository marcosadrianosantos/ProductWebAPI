using ProductProject.Domain.Models.Response;

namespace ProductProject.Test.Mocks
{
    public class ProductMock
    {
        public static List<Product> LstProducts => new()
        {
            new Product{Id = "6564088c2a0aa676d76b470f", Name = "Category 1", Description = "Description Category 1", Color = "Blue", Price = 10, 
                    CategoryId = "6561136cd4369dfea8c23744" , Category = CategoryMock.LstCategories.FirstOrDefault(x => x.Id == "6561136cd4369dfea8c23744")},
            new Product{Id = "656409b2f9361e5ebdadf586", Name = "Category 2", Description = "Description Category 2", Color = "Red", Price = 10 ,
                    CategoryId = "656400412a0aa676d76b470d" , Category = CategoryMock.LstCategories.FirstOrDefault(x => x.Id == "656400412a0aa676d76b470d")},
            new Product{Id = "656409d6f9361e5ebdadf587", Name = "Category 3", Description = "Description Category 3", Color = "White", Price = 10,
                    CategoryId = "656400482a0aa676d76b470e" , Category = CategoryMock.LstCategories.FirstOrDefault(x => x.Id == "656400482a0aa676d76b470e")},
            new Product{Id = "656409eef9361e5ebdadf588", Name = "Category 4", Description = "Description Category 4", Color = "Black", Price = 10,
                    CategoryId = "6564ac6ef9361e5ebdadf589" , Category = CategoryMock.LstCategories.FirstOrDefault(x => x.Id == "6564ac6ef9361e5ebdadf589")}
        };
    }
}
