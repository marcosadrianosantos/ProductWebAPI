using AutoMapper;
using ProductProject.Application.Interfaces;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Request;
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

        public async Task<Category> GetByIdAsync(string categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            return _mapper.Map<Category>(category);
        }

        public async Task<Category> CreateCategoryAsync(CategoryRequest categoryRequest)
        {
            try
            {
                Validate(categoryRequest.Name, categoryRequest.Description);

                var category = _mapper.Map<Category>(categoryRequest);

                await _repository.AddAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> UpdateAsync(string id, CategoryRequest categoryRequest)
        {
            try
            {
                var verifyCategoryExist = await _repository.GetByIdAsync(id);
                if(verifyCategoryExist == null)
                {
                    throw new Exception("Category not found");
                }

                Validate(categoryRequest.Name, categoryRequest.Description);

                var categoryUpdate = _mapper.Map(categoryRequest,verifyCategoryExist);
                await _repository.UpdateAsync(id, categoryUpdate);

                return _mapper.Map<Category>(categoryUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var productWithCategoryId = await _productRepository.GetByCategoryId(id);
                if(productWithCategoryId != null)
                {
                    throw new Exception("The category canoot be deleted as it is associated with some products.");
                }

                var category = await _repository.GetByIdAsync(id);
                if(category == null)
                {
                    throw new Exception("Category not found");
                }

                var result = await _repository.DeleteAsync(id);

                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static void Validate(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Field 'Name' cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Field 'Description' cannot be null or empty");
            }
        }
    }
}
