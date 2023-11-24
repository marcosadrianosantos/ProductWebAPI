using AutoMapper;
using ProductProject.Domain.Models.Request;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.AutoMapperConfiguration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            #region RequestToResponse
            CreateMap<CategoryRequest, Category>();
            CreateMap<ProductRequest, Product>();
            #endregion

            #region ResponseToRequest
            CreateMap<Category, CategoryRequest>();
            CreateMap<Product, ProductRequest>();
            #endregion
        }
    }
}
