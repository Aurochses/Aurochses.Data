using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IUnitOfWorkAsyncTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public IUnitOfWorkAsyncTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
        }

        [Fact]
        public async Task CommitAsync_Success()
        {
            const int result = 1;

            _mockUnitOfWork.Setup(m => m.CommitAsync()).ReturnsAsync(result);

            Assert.Equal(result, await _mockUnitOfWork.Object.CommitAsync());
        }
    }
}
