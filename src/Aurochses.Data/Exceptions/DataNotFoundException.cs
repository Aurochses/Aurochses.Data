using System;

namespace Aurochses.Data.Exceptions
{
    /// <summary>
    /// Is used to indicate that data is not found.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DataNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataNotFoundException"/> class.
        /// </summary>
        public DataNotFoundException()
            : base("The data you have requested has not been found.")
        {

        }
    }
}