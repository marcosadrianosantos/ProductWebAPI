using AutoMapper;
using ProductProject.Application.Interfaces;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(IProductRepository productRepository, ICategoryRepository repository, IMapper mapper)
        {
            _productRepository = productRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Category> GetById(string categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            return _mapper.Map<Category>(category);
        }
    }
}
