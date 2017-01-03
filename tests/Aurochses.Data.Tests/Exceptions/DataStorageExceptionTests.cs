using Aurochses.Data.Exceptions;
using System;
using Xunit;

namespace Aurochses.Data.Tests.Exceptions
{
    public class DataStorageExceptionTests
    {
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
