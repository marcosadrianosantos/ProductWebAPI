using ProductProject.Domain.Models.Request;

namespace ProductProject.Test.Mocks
{
    public class CategoryRequestMock
    {
        public static CategoryRequest CategoryRequest => new()
        {
            Name = "Test 1 Category",
            Description = "Test 1 Category - Description"
        };
    }
}
