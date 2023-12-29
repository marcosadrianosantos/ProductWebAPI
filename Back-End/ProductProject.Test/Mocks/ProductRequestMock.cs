using ProductProject.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Test.Mocks
{
    public class ProductRequestMock
    {
        public static ProductRequest ProductRequest => new()
        {
            Name = "Test Name 1",
            Description = "Test Name 1 Description",
            Price = 10.5m,
            Color = "Red",
            CategoryId = "6561136cd4369dfea8c23744"
        };
    }
}
