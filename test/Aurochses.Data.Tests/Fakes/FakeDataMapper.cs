using System;
using System.Linq;

namespace Aurochses.Data.Tests.Fakes
{
    public class FakeDataMapper : IDataMapper
    {
        public IQueryable<TDestination> Map<TDestination>(IQueryable source)
        {
            throw new Exception("Map is fake method!");
        }
    }
}