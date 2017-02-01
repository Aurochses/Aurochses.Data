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
            var dataStorageException = new DataStorageException(new Exception());

            // ReSharper disable once IsExpressionAlwaysTrue
            Assert.True(dataStorageException is Exception);
        }

        [Fact]
        public void Constuctor_NewItem_Created()
        {
            const string message = "test exception";

            var exception = new Exception(message);
            var dataStorageException = new DataStorageException(exception);

            Assert.Equal(message, dataStorageException.Message);
            Assert.IsType(exception.GetType(), dataStorageException.InnerException);
        }
    }
}
