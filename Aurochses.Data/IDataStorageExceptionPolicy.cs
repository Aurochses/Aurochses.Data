using System;

namespace Aurochses.Data
{
    /// <summary>
    /// Interface of exception policy for data storage.
    /// </summary>
    public interface IDataStorageExceptionPolicy<in TException>
        where TException : Exception
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <exception cref="Exceptions.DataStorageException"></exception>
        void HandleException(TException exception);
    }
}