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
        public void Get_ByQueryParameters_ReturnEntity()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Get(queryParameters)).Returns(entity);

            // Act & Assert
            Assert.Equal(entity, _mockRepository.Object.Get(queryParameters));
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
        public void GetTModel_ByQueryParameters_ReturnModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var model = new FakeModel();

            _mockRepository.Setup(m => m.Get<FakeModel>(dataMapper, queryParameters)).Returns(model);

            // Act & Assert
            Assert.Equal(model, _mockRepository.Object.Get<FakeModel>(dataMapper, queryParameters));
        }

        [Fact]
        public void GetList_ByQueryParameters_ReturnListOfEntity()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.GetList(queryParameters)).Returns(new List<FakeEntity> { entity });

            // Act & Assert
            Assert.Contains(entity, _mockRepository.Object.GetList(queryParameters));
        }

        [Fact]
        public void GetListTModel_ByQueryParameters_ReturnListOfModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var model = new FakeModel();

            _mockRepository.Setup(m => m.GetList<FakeModel>(dataMapper, queryParameters)).Returns(new List<FakeModel> { model });

            // Act & Assert
            Assert.Contains(model, _mockRepository.Object.GetList<FakeModel>(dataMapper, queryParameters));
        }

        [Fact]
        public void GetPagedList_ByQueryParameters_ReturnListOfEntity()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var pagedResult = new PagedResult<FakeEntity>();

            _mockRepository.Setup(m => m.GetPagedList(queryParameters)).Returns(pagedResult);

            // Act & Assert
            Assert.Equal(pagedResult, _mockRepository.Object.GetPagedList(queryParameters));
        }

        [Fact]
        public void GetPagedListTModel_ByQueryParameters_ReturnListOfModel()
        {
            // Arrange
            var dataMapper = new FakeDataMapper();
            var queryParameters = new QueryParameters<FakeEntity, int>();
            var pagedResult = new PagedResult<FakeModel>();

            _mockRepository.Setup(m => m.GetPagedList<FakeModel>(dataMapper, queryParameters)).Returns(pagedResult);

            // Act & Assert
            Assert.Equal(pagedResult, _mockRepository.Object.GetPagedList<FakeModel>(dataMapper, queryParameters));
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
        public void Exists_ByQueryParameters_ReturnEntity()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();

            _mockRepository.Setup(m => m.Exists(queryParameters)).Returns(true);

            // Act & Assert
            Assert.True(_mockRepository.Object.Exists(queryParameters));
        }

        [Fact]
        public void Count_ByQueryParameters_ReturnModel()
        {
            // Arrange
            var queryParameters = new QueryParameters<FakeEntity, int>();

            _mockRepository.Setup(m => m.Count(queryParameters)).Returns(1);

            // Act & Assert
            Assert.Equal(1, _mockRepository.Object.Count(queryParameters));
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