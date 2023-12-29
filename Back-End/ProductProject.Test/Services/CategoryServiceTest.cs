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
    public class CategoryServiceTest : BaseServiceTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly CategoryRequest _categoryRequest;
        private readonly Mock<IMapper> _mapper;
        private readonly CategoryService _service; 

        public CategoryServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _categoryRepository = new Mock<ICategoryRepository>();
            _mapper = new Mock<IMapper>();
            _categoryRequest = Mocks.CategoryRequestMock.CategoryRequest;
            _categoryRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(() => Mocks.CategoryMock.LstCategories);
            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>(async (id) => await Task.Run(() => Mocks.CategoryMock.LstCategories.FirstOrDefault(x => x.Id.Equals(id))));
            _productRepository.Setup(x => x.GetByCategoryId(It.IsAny<string>())).Returns<string>(async (id) => await Task.Run(() => Mocks.ProductMock.LstProducts.FirstOrDefault(x => x.CategoryId.Equals(id))));
            _service = new CategoryService(_productRepository.Object, _categoryRepository.Object, _mapper.Object);
        }

        #region CreateCategoryAsync

        [Fact]
        public async Task Category_Create_Sucess()
        {
            _mapper.Setup(x => x.Map<Category>(It.IsAny<CategoryRequest>())).Returns<CategoryRequest>((c) => new Category { Description = c.Description, Name = c.Name, Id = "65826069316c436eb046ff61" });
            var result = await _service.CreateCategoryAsync(_categoryRequest);
            Assert.NotNull(result);
            Assert.Equal("65826069316c436eb046ff61", result.Id);
            Assert.Equal(_categoryRequest.Name, result.Name);
            Assert.Equal(_categoryRequest.Description, result.Description);
        }

        [Fact]
        public async Task Category_Create_Error_Name_Null()
        {
            _categoryRequest.Name = null;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateCategoryAsync(_categoryRequest));
        }

        [Fact]
        public async Task Category_Create_Error_Description_Null()
        {
            _categoryRequest.Description = null;
            await Assert.ThrowsAsync<Exception>(() => _service.CreateCategoryAsync(_categoryRequest));
        }

        #endregion

        #region GetAllAsync

        [Fact]
        public async Task Category_Get_All_Sucess()
        {
            var result = await _service.GetAllAsync();
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Equal(Mocks.CategoryMock.LstCategories.Count, result.Count());
        }

        #endregion

        #region GetByIdAsync

        [Fact]
        public async Task Category_Get_By_Id_Error()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.GetByIdAsync("1"));
        }

        [Fact]
        public async Task Category_Get_By_Id_Sucess()
        {
            var result = await _service.GetByIdAsync("6564ac6ef9361e5ebdadf589");
            Assert.NotNull(result);
        }

        #endregion

        #region UpdateAsync

        [Fact]
        public async Task Category_Update_Error_Category_Not_Found()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync("1",_categoryRequest));
        }

        [Fact]
        public async Task Category_Update_Sucess()
        {
            _mapper.Setup(x => x.Map(It.IsAny<CategoryRequest>(), It.IsAny<Category>())).Returns<CategoryRequest, Category>((request, model) 
                    => { return new Category { Id = "6564ac6ef9361e5ebdadf589", Description = "Test 1 Category - Description",Name = "Test 1 Category" }; });
            var result = await _service.UpdateAsync("6564ac6ef9361e5ebdadf589", _categoryRequest);
            Assert.NotNull(result);
            Assert.Equal("6564ac6ef9361e5ebdadf589", result.Id);
            Assert.Equal(_categoryRequest.Name, result.Name);
            Assert.Equal(_categoryRequest.Description, result.Description);

        }

        #endregion

        #region DeleteAsync

        [Fact]
        public async Task Category_Delete_Category_Associated_Error()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.DeleteAsync("6564ac6ef9361e5ebdadf589"));
        }

        [Fact]
        public async Task Category_Delete_Not_Found()
        {
            await Assert.ThrowsAsync<Exception>(() => _service.DeleteAsync("1"));
        }

        [Fact]
        public async Task Category_Delete_Sucess()
        {
            var deleteResultMock = new Mock<DeleteResult>();
            deleteResultMock.Setup(x => x.IsAcknowledged).Returns(true);
            deleteResultMock.Setup(x => x.DeletedCount).Returns(1);
            _categoryRepository.Setup(x => x.DeleteAsync(It.IsAny<string>())).ReturnsAsync(deleteResultMock.Object);
            
            var result = await _service.DeleteAsync("65874b197561e4f287442c1c");
            Assert.True(result);
        }
        #endregion
    }
}
