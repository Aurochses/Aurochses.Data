using Moq;
using System;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IUnitOfWorkTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public IUnitOfWorkTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Inherit_IEquatable()
        {
            // ReSharper disable once IsExpressionAlwaysTrue
            Assert.True(_mockUnitOfWork.Object is IDisposable);
        }

        [Fact]
        public void Commit_Success()
        {
            const int result = 1;

            _mockUnitOfWork.Setup(m => m.Commit()).Returns(result);

            Assert.Equal(result, _mockUnitOfWork.Object.Commit());
        }
    }
}
