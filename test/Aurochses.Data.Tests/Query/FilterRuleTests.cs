using System;
using System.Linq.Expressions;
using Aurochses.Data.Query;
using Aurochses.Data.Tests.Fakes;
using Xunit;

namespace Aurochses.Data.Tests.Query
{
    public class FilterRuleTests
    {
        private readonly FilterRule<FakeEntity, int> _filterRule;

        public FilterRuleTests()
        {
            _filterRule = new FilterRule<FakeEntity, int>();
        }

        [Fact]
        public void Expression_Success()
        {
            // Arrange
            Expression<Func<FakeEntity, bool>> expression = x => x.Id == 1;

            // Act
            _filterRule.Expression = expression;

            // Assert
            Assert.Equal(expression, _filterRule.Expression);
        }
    }
}