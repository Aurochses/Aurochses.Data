using Aurochses.Data.Tests.Fakes;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IRepositoryAsyncTests
    {
        [Fact]
        public async Task GetAsync_ById_ReturnEntity()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.GetAsync(1)).ReturnsAsync(entity);

            Assert.Equal(entity, await mockRepository.Object.GetAsync(1));
        }

        [Fact]
        public async Task GetAsync_ByExpression_ReturnEntity()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.GetAsync(x => x.Id == 1)).ReturnsAsync(new List<FakeEntity> { entity });

            Assert.Contains(entity, await mockRepository.Object.GetAsync(x => x.Id == 1));
        }

        [Fact]
        public async Task ExistsAsync_ById_Success()
        {
            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.ExistsAsync(1)).ReturnsAsync(true);

            Assert.True(await mockRepository.Object.ExistsAsync(1));
        }

        [Fact]
        public async Task ExistsAsync_ByExpression_ReturnEntity()
        {
            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.ExistsAsync(x => x.Id == 1)).ReturnsAsync(true);

            Assert.True(await mockRepository.Object.ExistsAsync(x => x.Id == 1));
        }

        [Fact]
        public async Task InsertOrUpdateAsync_Entity_Success()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.InsertOrUpdateAsync(entity, false)).ReturnsAsync(entity);

            Assert.Equal(entity, await mockRepository.Object.InsertOrUpdateAsync(entity, false));
        }
    }
}
