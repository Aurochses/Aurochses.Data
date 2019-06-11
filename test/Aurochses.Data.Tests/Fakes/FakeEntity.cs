using System;
using System.Diagnostics.CodeAnalysis;

namespace Aurochses.Data.Tests.Fakes
{
    [ExcludeFromCodeCoverage]
    public class FakeEntity : IEntity<int>
    {
        public int Id { get; set; }

        public bool Equals(IEntity<int> other)
        {
            throw new Exception("Equals is fake method!");
        }
    }
}