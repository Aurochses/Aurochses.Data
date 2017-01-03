using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IUnitOfWorkAsyncTests
    {
        [Fact]
        public async Task CommitAsync_Success()
        {
            const int result = 1;

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.CommitAsync()).ReturnsAsync(result);

            Assert.Equal(result, await mockUnitOfWork.Object.CommitAsync());
        }
    }
}
