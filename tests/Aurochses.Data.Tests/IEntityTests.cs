using Moq;
using System;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IEntityTests
    {
        [Fact]
        public void Inherit_IEquatable()
        {
            var mockEntity = new Mock<IEntity<int>>();

            Assert.True(mockEntity.Object is IEquatable<IEntity<int>>);
        }

        [Fact]
        public void Id_Get_Success()
        {
            const int id = 1;

            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.SetupGet(m => m.Id).Returns(id);

            Assert.Equal(id, mockEntity.Object.Id);
        }

        [Fact]
        public void Id_Set_Success()
        {
            const int id = 1;

            var result = 0;
            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.SetupSet(m => m.Id).Callback(value => { result = value; });

            mockEntity.Object.Id = id;

            Assert.Equal(id, result);
        }

        [Fact]
        public void IsNew_Entity_Success()
        {
            const bool isNew = true;

            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.Setup(m => m.IsNew()).Returns(isNew);

            Assert.Equal(isNew, mockEntity.Object.IsNew());
        }
    }
}
