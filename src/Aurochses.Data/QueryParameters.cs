﻿using System;
using System.Linq.Expressions;
using Aurochses.Data.Query;

namespace Aurochses.Data
{
    /// <summary>
    /// Query parameters class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <typeparam name="TType">The type of the T type.</typeparam>
    public class QueryParameters<TEntity, TType>
        where TEntity : class, IEntity<TType>
    {
        /// <summary>
        /// Gets or sets filter rule.
        /// </summary>
        public FilterRule<TEntity, TType> Filter { get; set; }

        /// <summary>
        /// Gets or sets sort rule.
        /// </summary>
        public SortRule<TEntity, TType> Sort { get; set; }

        /// <summary>
        /// Gets or sets page rule.
        /// </summary>
        public PageRule Page { get; set; }

        internal static QueryParameters<TEntity, TType> Create(Expression<Func<TEntity, bool>> filterExpression)
        {
            return new QueryParameters<TEntity, TType>
            {
                Filter = new FilterRule<TEntity, TType>
                {
                    Expression = filterExpression
                }
            };
        }
    }
}