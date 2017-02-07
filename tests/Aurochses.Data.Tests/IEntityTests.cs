using Moq;
using System;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IEntityTests
    {
        private readonly Mock<IEntity<int>> _mockEntity;

        public IEntityTests()
        {
            _mockEntity = new Mock<IEntity<int>>();
        }

        [Fact]
        public void Inherit_IEquatable()
        {
            // ReSharper disable once IsExpressionAlwaysTrue
            Assert.True(_mockEntity.Object is IEquatable<IEntity<int>>);
        }

        [Fact]
        public void Id_Get_Success()
        {
            const int id = 1;

            _mockEntity.SetupGet(m => m.Id).Returns(id);

            Assert.Equal(id, _mockEntity.Object.Id);
        }

        [Fact]
        public void Id_Set_Success()
        {
            var result = 0;

            const int id = 1;

            _mockEntity.SetupSet(m => m.Id = It.IsAny<int>()).Callback((int value) => { result = value; });

            _mockEntity.Object.Id = id;

            Assert.Equal(id, result);
        }

        [Fact]
        public void IsNew_Entity_Success()
        {
            const bool isNew = true;

            _mockEntity.Setup(m => m.IsNew()).Returns(isNew);

            Assert.Equal(isNew, _mockEntity.Object.IsNew());
        }
    }
}
