﻿using System;
using System.Linq.Expressions;

namespace Aurochses.Data.Query
{
    /// <summary>
    /// Filter rule class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <typeparam name="TType">The type of the T type.</typeparam>
    public class FilterRule<TEntity, TType>
        where TEntity : IEntity<TType>
    {
        /// <summary>
        /// Gets or sets filter expression.
        /// </summary>
        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}