using Aurochses.Data.Tests.Fakes;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Aurochses.Data.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IRepositoryTests
    {
        private readonly Mock<IRepository<FakeEntity, int>> _mockRepository;

        public IRepositoryTests()
        {
            _mockRepository = new Mock<IRepository<FakeEntity, int>>(MockBehavior.Strict);
        }

        [Fact]
        public void Get_ById_ReturnEntity()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Get(1)).Returns(entity);

            Assert.Equal(entity, _mockRepository.Object.Get(1));
        }

        [Fact]
        public void GetTModel_ById_ReturnModel()
        {
            var model = new FakeModel();

            _mockRepository.Setup(m => m.Get<FakeModel>(1)).Returns(model);

            Assert.Equal(model, _mockRepository.Object.Get<FakeModel>(1));
        }

        [Fact]
        public void Get_ByExpression_ReturnListOfEntity()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Get(x => x.Id == 1)).Returns(new List<FakeEntity> { entity });

            Assert.Contains(entity, _mockRepository.Object.Get(x => x.Id == 1));
        }

        [Fact]
        public void GetTModel_ByExpression_ReturnListOfModel()
        {
            var model = new FakeModel();

            _mockRepository.Setup(m => m.Get<FakeModel>(x => x.Id == 1)).Returns(new List<FakeModel> { model });

            Assert.Contains(model, _mockRepository.Object.Get<FakeModel>(x => x.Id == 1));
        }

        [Fact]
        public void Exists_ById_Success()
        {
            _mockRepository.Setup(m => m.Exists(1)).Returns(true);

            Assert.True(_mockRepository.Object.Exists(1));
        }

        [Fact]
        public void Exists_ByExpression_ReturnEntity()
        {
            _mockRepository.Setup(m => m.Exists(x => x.Id == 1)).Returns(true);

            Assert.True(_mockRepository.Object.Exists(x => x.Id == 1));
        }

        [Fact]
        public void InsertOrUpdate_Entity_Success()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.InsertOrUpdate(entity, false)).Returns(entity);

            Assert.Equal(entity, _mockRepository.Object.InsertOrUpdate(entity));
        }

        [Fact]
        public void Delete_ById_Success()
        {
            _mockRepository.Setup(m => m.Delete(1)).Verifiable();

            _mockRepository.Object.Delete(1);

            _mockRepository.Verify();
        }

        [Fact]
        public void Delete_ByEntity_Success()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Delete(entity)).Verifiable();

            _mockRepository.Object.Delete(entity);

            _mockRepository.Verify();
        }
    }
}
