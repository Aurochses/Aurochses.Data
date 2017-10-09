using System;
using System.Linq;
using System.Reflection;
using Aurochses.Data.Query;
using Xunit;

namespace Aurochses.Data.Tests.Query
{
    public class SortOrderTests
    {
        [Fact]
        public void IsEnum()
        {
            // Arrange & Act & Assert
            Assert.True(typeof(SortOrder).GetTypeInfo().IsEnum);
        }

        [Fact]
        public void Validate_Values()
        {
            // Arrange & Act & Assert
            foreach (var value in Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>())
            {
                switch (value)
                {
                    case SortOrder.Ascending:
                    {
                        Assert.Equal(0, (int) value);
                        break;
                    }
                    case SortOrder.Descending:
                    {
                        Assert.Equal(1, (int) value);
                        break;
                    }
                    default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid enum value.");
                    }
                }
            }
        }
    }
}