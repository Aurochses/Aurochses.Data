using Moq;
using System;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IUnitOfWorkTests
    {
        [Fact]
        public void Inherit_IEquatable()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            Assert.True(mockUnitOfWork.Object is IDisposable);
        }

        [Fact]
        public void Commit_Success()
        {
            const int result = 1;

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.Commit()).Returns(result);

            Assert.Equal(result, mockUnitOfWork.Object.Commit());
        }
    }
}
