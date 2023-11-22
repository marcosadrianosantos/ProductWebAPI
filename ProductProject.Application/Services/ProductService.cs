using AutoMapper;
using ProductProject.Application.Interfaces;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Request;
using ProductProject.Domain.Models.Response;

namespace ProductProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        

        public ProductService(IProductRepository productRepository, ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductRequest productRequest)
        {
            try
            {
                var category = await _categoryService.GetById(productRequest.CategoryId);
                if(category == null)
                {
                    throw new Exception("Category not found");
                }

                Validate(productRequest.Name, productRequest.Description, productRequest.Price, productRequest.CategoryId);

                var product = _mapper.Map<Product>(productRequest);

                await _productRepository.AddAsync(product);
                return product;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync(); 
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if(product == null)
                {
                    throw new Exception("Product not found");
                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateAsync(string id, ProductRequest productRequest)
        {
            try
            {
                var category = await _categoryService.GetById(productRequest.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }

                var productUpdate = _mapper.Map<Product>(productRequest);

                await _productRepository.UpdateAsync(id, productUpdate);

                return productUpdate;
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
                var product = await _productRepository.GetByIdAsync(id);

                if(product == null)
                {
                    throw new Exception("Product not found");
                }

                var result = await _productRepository.DeleteAsync(id);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete the product", ex.InnerException);
            }
        }

        private static void Validate(string name, string description, decimal price, string categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Field 'Name' cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Field 'Description' cannot be null or empty");
            }

            if (!description.Contains(name))
            {
                throw new Exception("Field 'Description' must contain the product name inside");
            }

            if (price <= 0)
            {
                throw new Exception("Field 'Price' must be greater than zero");
            }

            if (string.IsNullOrWhiteSpace(categoryId))
            {
                throw new Exception("category cannot be null");
            }
        }
    }
}
