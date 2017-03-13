using System;

namespace Aurochses.Data.Tests.Fakes
{
    public class FakeEntity : IEntity<int>
    {
        public int Id { get; set; }

        public bool Equals(IEntity<int> other)
        {
            throw new Exception("Equals is fake method!");
        }

        public bool IsNew()
        {
            throw new Exception("IsNew is fake method!");
        }
    }
}
