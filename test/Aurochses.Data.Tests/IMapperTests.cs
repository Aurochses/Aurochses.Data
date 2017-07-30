using System.Collections.Generic;
using System.Linq;
using Aurochses.Data.Tests.Fakes;
using Moq;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IMapperTests
    {
        private readonly Mock<IMapper> _mockMapper;

        public IMapperTests()
        {
            _mockMapper = new Mock<IMapper>(MockBehavior.Strict);
        }

        [Fact]
        public void Map_IQueryable_ReturnQueryableOfDestination()
        {
            // Arrange
            var queryable = new List<FakeEntity>().AsQueryable();
            var expected = new List<FakeModel>().AsQueryable();

            _mockMapper.Setup(m => m.Map<FakeModel>(queryable)).Returns(expected);

            // Act & Assert
            Assert.Equal(expected, _mockMapper.Object.Map<FakeModel>(queryable));
        }
    }
}