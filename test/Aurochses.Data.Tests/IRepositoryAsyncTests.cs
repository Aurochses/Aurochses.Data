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
            var model = new FakeModel();

            _mockRepository.Setup(m => m.GetAsync<FakeModel>(1)).ReturnsAsync(model);

            // Act & Assert
            Assert.Equal(model, await _mockRepository.Object.GetAsync<FakeModel>(1));
        }

        [Fact]
        public async Task GetAsync_ByExpression_ReturnListOfEntity()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.GetAsync(x => x.Id == 1)).ReturnsAsync(new List<FakeEntity> { entity });

            // Act & Assert
            Assert.Contains(entity, await _mockRepository.Object.GetAsync(x => x.Id == 1));
        }

        [Fact]
        public async Task GetTModelAsync_ByExpression_ReturnListOfModel()
        {
            // Arrange
            var model = new FakeModel();

            _mockRepository.Setup(m => m.GetAsync<FakeModel>(x => x.Id == 1)).ReturnsAsync(new List<FakeModel> { model });

            // Act & Assert
            Assert.Contains(model, await _mockRepository.Object.GetAsync<FakeModel>(x => x.Id == 1));
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
        public async Task ExistsAsync_ByExpression_ReturnEntity()
        {
            // Arrange
            _mockRepository.Setup(m => m.ExistsAsync(x => x.Id == 1)).ReturnsAsync(true);

            // Act & Assert
            Assert.True(await _mockRepository.Object.ExistsAsync(x => x.Id == 1));
        }

        [Fact]
        public async Task InsertOrUpdateAsync_Entity_Success()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.InsertOrUpdateAsync(entity, false)).ReturnsAsync(entity);

            // Act & Assert
            Assert.Equal(entity, await _mockRepository.Object.InsertOrUpdateAsync(entity));
        }
    }
}