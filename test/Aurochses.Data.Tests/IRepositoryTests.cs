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
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Get(1)).Returns(entity);

            // Act & Assert
            Assert.Equal(entity, _mockRepository.Object.Get(1));
        }

        [Fact]
        public void GetTModel_ById_ReturnModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var model = new FakeModel();

            _mockRepository.Setup(m => m.Get<FakeModel>(dataMapper, 1)).Returns(model);

            // Act & Assert
            Assert.Equal(model, _mockRepository.Object.Get<FakeModel>(dataMapper, 1));
        }

        [Fact]
        public void Find_ByExpression_ReturnListOfEntity()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Find(x => x.Id == 1)).Returns(new List<FakeEntity> { entity });

            // Act & Assert
            Assert.Contains(entity, _mockRepository.Object.Find(x => x.Id == 1));
        }

        [Fact]
        public void FindTModel_ByExpression_ReturnListOfModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var model = new FakeModel();

            _mockRepository.Setup(m => m.Find<FakeModel>(dataMapper, x => x.Id == 1)).Returns(new List<FakeModel> { model });

            // Act & Assert
            Assert.Contains(model, _mockRepository.Object.Find<FakeModel>(dataMapper, x => x.Id == 1));
        }

        [Fact]
        public void Exists_ById_Success()
        {
            // Arrange
            _mockRepository.Setup(m => m.Exists(1)).Returns(true);

            // Act & Assert
            Assert.True(_mockRepository.Object.Exists(1));
        }

        [Fact]
        public void Exists_ByExpression_ReturnEntity()
        {
            // Arrange
            _mockRepository.Setup(m => m.Exists(x => x.Id == 1)).Returns(true);

            // Act & Assert
            Assert.True(_mockRepository.Object.Exists(x => x.Id == 1));
        }

        [Fact]
        public void Insert_Entity_Success()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Insert(entity)).Returns(entity);

            // Act & Assert
            Assert.Equal(entity, _mockRepository.Object.Insert(entity));
        }

        [Fact]
        public void Update_Entity_Success()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Update(entity, false)).Returns(entity);

            // Act & Assert
            Assert.Equal(entity, _mockRepository.Object.Update(entity));
        }

        [Fact]
        public void Delete_ById_Success()
        {
            // Arrange
            _mockRepository.Setup(m => m.Delete(1)).Verifiable();

            // Act
            _mockRepository.Object.Delete(1);

            // Assert
            _mockRepository.Verify();
        }

        [Fact]
        public void Delete_ByEntity_Success()
        {
            // Arrange
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Delete(entity)).Verifiable();

            // Act
            _mockRepository.Object.Delete(entity);

            // Assert
            _mockRepository.Verify();
        }
    }
}