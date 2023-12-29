using AutoMapper;
using ProductProject.Application.AutoMapperConfiguration;

namespace ProductProject.Test.Services
{
    public class BaseServiceTest
    {
        protected IMapper setMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingConfiguration());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
