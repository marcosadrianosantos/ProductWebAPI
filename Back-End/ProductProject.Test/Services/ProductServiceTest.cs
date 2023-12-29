using AutoMapper;
using MongoDB.Driver;
using Moq;
using ProductProject.Application.Services;
using ProductProject.Domain.Interfaces.Repositories;
using ProductProject.Domain.Models.Request;
using ProductProject.Domain.Models.Response;
using Xunit;

namespace ProductProject.Test.Services
{
    public class ProductServiceTest : BaseServiceTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly ProductRequest _productRequest;
        private readonly Mock<IMapper> _mapper;
        private readonly ProductService _service;

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _categoryRepository = new Mock<ICategoryRepository>();
            _mapper = new Mock<IMapper>();
            _productRequest = Mocks.ProductRequestMock.ProductRequest;
            _productRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(() => Mocks.ProductMock.LstProducts);
            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>(async (id) => await Task.Run(() => Mocks.ProductMock.LstProducts.FirstOrDefault(x => x.Id.Equals(id))));
            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>(async (id) => await Task.Run(() => Mocks.CategoryMock.LstCategories.FirstOrDefault(x => x.Id.Equals(id))));
            _service = new ProductService(_productRepository.Object, _categoryRepository.Object, _mapper.Object);
        }

        #region CreateProductAsync
        [Fact]
        public async Task Product_Create_Error_Category_Not_Found()
        {
            _productRequest.CategoryId = "1";
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Error_Name_Null()
        {
            _productRequest.Name = null;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Error_Description_Null()
        {
            _productRequest.Description = null;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Error_Description_Not_Contains_Name_Null()
        {
            _productRequest.Name = "Test Name";
            _productRequest.Description = "Test Description";
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Error_Price_Less_Than_Zero_Null()
        {
            _productRequest.Price = 0;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Error_CategoryId_Null()
        {
            _productRequest.CategoryId = null;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateProductAsync(_productRequest));
        }

        [Fact]
        public async Task Product_Create_Sucess()
        {
            _mapper.Setup(x => x.Map<Product>(It.IsAny<ProductRequest>()))
                .Returns<ProductRequest>((p) => new Product { Name = p.Name, Description = p.Description, Color = p.Color, CategoryId = p.CategoryId, Price = p.Price, Id = "65665336612cc119334e1365" });
            var result = await _service.CreateProductAsync(_productRequest);
            Assert.NotNull(result);
            Assert.Equal("65665336612cc119334e1365", result.Id);
            Assert.Equal(_productRequest.Name, result.Name);
            Assert.Equal(_productRequest.Description, result.Description);
            Assert.Equal(_productRequest.Color, result.Color);
            Assert.Equal(_productRequest.CategoryId, result.CategoryId);
            Assert.Equal(_productRequest.Price.ToString(), result.Price.ToString());
        }

        #endregion

        #region GetAllAsync

        [Fact]
        public async Task Product_Get_All_Sucess()
        {
            var result = await _service.GetAllAsync();
            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
            Assert.Equal(Mocks.ProductMock.LstProducts.Count, result.Count());
        }

        #endregion

        #region GetByIdAsync

        [Fact]
        public async Task Product_Get_By_Id_Error()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.GetByIdAsync("1"));
        }

        [Fact]
        public async Task Product_Get_By_Id_Sucess()
        {
            var result = await _service.GetByIdAsync("6564088c2a0aa676d76b470f");
            Assert.NotNull(result);
        }

        #endregion

        #region UpdateAsync

        [Fact]
        public async Task Product_Update_Category_Not_Found_Error()
        {
            _productRequest.CategoryId = "1";
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync("65654cdae25022aa19d68d6c", _productRequest));
        }

        [Fact]
        public async Task Product_Update_Product_Not_Found_Error()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync("1", _productRequest));
        }

        [Fact]
        public async Task Product_Update_Sucess()
        {
            _mapper.Setup(x => x.Map(It.IsAny<ProductRequest>(), It.IsAny<Product>())).Returns<ProductRequest, Product>((request, model)
                => { return new Product { Id = "656409eef9361e5ebdadf588", Description = "Test Name 1 Description", Name = "Test Name 1", CategoryId = "6561136cd4369dfea8c23744", Color = "Red", Price = 10.5m }; });
            var result = await _service.UpdateAsync("656409eef9361e5ebdadf588", _productRequest);
            Assert.NotNull(result);
            Assert.Equal("656409eef9361e5ebdadf588", result.Id);
            Assert.Equal(_productRequest.Name, result.Name);
            Assert.Equal(_productRequest.Description, result.Description);
            Assert.Equal(_productRequest.Color, result.Color);
            Assert.Equal(_productRequest.CategoryId, result.CategoryId);
            Assert.Equal(_productRequest.Price.ToString(), result.Price.ToString());

        }

        #endregion 

        #region DeleteAsync

        [Fact]
        public async Task Product_Delete_Product_Not_Found()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.DeleteAsync("1"));
        }

        [Fact]
        public async Task Product_Delete_Product_Sucess()
        {
            var deleteResultMock = new Mock<DeleteResult>();
            deleteResultMock.Setup(x => x.IsAcknowledged).Returns(true);
            deleteResultMock.Setup(x => x.DeletedCount).Returns(1);
            _productRepository.Setup(x => x.DeleteAsync(It.IsAny<string>())).ReturnsAsync(deleteResultMock.Object);

            var result = await _service.DeleteAsync("6564088c2a0aa676d76b470f");
            Assert.True(result);
        }

        #endregion

    }
}
