using System.Linq;

namespace Aurochses.Data
{
    /// <summary>
    /// Interface of mapper.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Method to map from a queryable using the provided mapping engine
        /// </summary>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Queryable source</param>
        /// <returns>Expression to map into</returns>
        IQueryable<TDestination> Map<TDestination>(IQueryable source);
    }
}