using Aurochses.Data.Exceptions;
using System;
using Xunit;

namespace Aurochses.Data.Tests.Exceptions
{
    public class DataStorageExceptionTests
    {
        [Fact]
        public void Inherit_Exception()
        {
            // Arrange
            var dataStorageException = new DataStorageException(new Exception());

            // Act & Assert
            Assert.IsAssignableFrom<Exception>(dataStorageException);
        }

        [Fact]
        public void Constuctor_NewItem_Created()
        {
            // Arrange
            const string message = "test exception";

            var exception = new Exception(message);
            var dataStorageException = new DataStorageException(exception);

            // Act & Assert
            Assert.Equal(message, dataStorageException.Message);
            Assert.IsType(exception.GetType(), dataStorageException.InnerException);
        }
    }
}
