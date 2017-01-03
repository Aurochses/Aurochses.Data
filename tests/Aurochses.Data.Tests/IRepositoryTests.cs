using Aurochses.Data.Tests.Fakes;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Aurochses.Data.Tests
{
    public class IRepositoryTests
    {
        [Fact]
        public void Get_ById_ReturnEntity()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Get(1)).Returns(entity);

            Assert.Equal(entity, mockRepository.Object.Get(1));
        }

        [Fact]
        public void Get_ByExpression_ReturnEntity()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Get(x => x.Id == 1)).Returns(new List<FakeEntity> { entity });

            Assert.Contains(entity, mockRepository.Object.Get(x => x.Id == 1));
        }

        [Fact]
        public void Exists_ById_Success()
        {
            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Exists(1)).Returns(true);

            Assert.True(mockRepository.Object.Exists(1));
        }

        [Fact]
        public void Exists_ByExpression_ReturnEntity()
        {
            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Exists(x => x.Id == 1)).Returns(true);

            Assert.True(mockRepository.Object.Exists(x => x.Id == 1));
        }

        [Fact]
        public void InsertOrUpdate_Entity_Success()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.InsertOrUpdate(entity, false)).Returns(entity);

            Assert.Equal(entity, mockRepository.Object.InsertOrUpdate(entity, false));
        }

        [Fact]
        public void Delete_ById_Success()
        {
            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Delete(1)).Verifiable();

            mockRepository.Object.Delete(1);

            mockRepository.Verify();
        }

        [Fact]
        public void Delete_ByEntity_Success()
        {
            var entity = new FakeEntity();

            var mockRepository = new Mock<IRepository<FakeEntity, int>>();
            mockRepository.Setup(m => m.Delete(entity)).Verifiable();

            mockRepository.Object.Delete(entity);

            mockRepository.Verify();
        }
    }
}
