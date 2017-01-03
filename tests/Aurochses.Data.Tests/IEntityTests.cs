using Moq;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IEntityTests
    {
        [Fact]
        public void Id_Get_Success()
        {
            const int id = 1;

            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.SetupGet(x => x.Id).Returns(id);

            Assert.Equal(id, mockEntity.Object.Id);
        }

        [Fact]
        public void Id_Set_Success()
        {
            const int id = 1;

            var result = 0;
            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.SetupSet(x => x.Id).Callback(value => { result = value; });

            mockEntity.Object.Id = id;

            Assert.Equal(id, result);
        }

        [Fact]
        public void IsNew_Entity_Success()
        {
            const bool isNew = true;

            var mockEntity = new Mock<IEntity<int>>();
            mockEntity.Setup(x => x.IsNew()).Returns(isNew);

            Assert.Equal(isNew, mockEntity.Object.IsNew());
        }
    }
}
