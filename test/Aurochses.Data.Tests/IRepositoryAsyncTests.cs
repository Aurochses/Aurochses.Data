using Aurochses.Data.Tests.Fakes;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IRepositoryAsyncTests
    {
        private readonly Mock<IRepository<FakeEntity, int>> _mockRepository;

        public IRepositoryAsyncTests()
        {
            _mockRepository = new Mock<IRepository<FakeEntity, int>>(MockBehavior.Strict);
        }

        [Fact]
        public async Task GetAsync_ById_ReturnEntity()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.GetAsync(1)).ReturnsAsync(entity);

            // Act & Assert
            Assert.Equal(entity, await _mockRepository.Object.GetAsync(1));
        }

        [Fact]
        public async Task GetTModelAsync_ById_ReturnModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var model = new FakeModel();

            _mockRepository.Setup(m => m.GetAsync<FakeModel>(dataMapper, 1)).ReturnsAsync(model);

            // Act & Assert
            Assert.Equal(model, await _mockRepository.Object.GetAsync<FakeModel>(dataMapper, 1));
        }

        [Fact]
        public async Task GetListAsync_ByQueryParameters_ReturnListOfEntity()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var entity = new FakeEntity();

            _mockRepository
                .Setup(m => m.GetListAsync(queryParameters))
                .ReturnsAsync(new List<FakeEntity> { entity });

            // Act & Assert
            Assert.Contains(entity, await _mockRepository.Object.GetListAsync(queryParameters));
        }

        [Fact]
        public async Task GetListTModelAsync_ByQueryParameters_ReturnListOfModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var model = new FakeModel();

            _mockRepository
                .Setup(m => m.GetListAsync<FakeModel>(dataMapper, queryParameters))
                .ReturnsAsync(new List<FakeModel> { model });

            // Act & Assert
            Assert.Contains(model, await _mockRepository.Object.GetListAsync<FakeModel>(dataMapper, queryParameters));
        }

        [Fact]
        public async Task ExistsAsync_ById_Success()
        {
            // Arrange
            _mockRepository.Setup(m => m.ExistsAsync(1)).ReturnsAsync(true);

            // Act & Assert
            Assert.True(await _mockRepository.Object.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistsAsync_ByQueryParameters_Success()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();

            _mockRepository.Setup(m => m.ExistsAsync(queryParameters)).ReturnsAsync(true);

            // Act & Assert
            Assert.True(await _mockRepository.Object.ExistsAsync(queryParameters));
        }

        [Fact]
        public async Task CountAsync_ByQueryParameters_Success()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();

            _mockRepository.Setup(m => m.CountAsync(queryParameters)).ReturnsAsync(1);

            // Act & Assert
            Assert.Equal(1, await _mockRepository.Object.CountAsync(queryParameters));
        }

        [Fact]
        public async Task InsertAsync_Entity_Success()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.InsertAsync(entity)).ReturnsAsync(entity);

            // Act & Assert
            Assert.Equal(entity, await _mockRepository.Object.InsertAsync(entity));
        }
    }
}