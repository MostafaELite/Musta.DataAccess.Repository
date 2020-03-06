using System;
using System.Linq;
using System.Linq.Expressions;

namespace Musta.DataAccess.Repository.Abstract
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns a ReadOnly IQueryable That match a specfic predicate
        /// </summary>
        /// <param name="predicate">the condition for retreving recrods from the database</param>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        
        /// <summary>
        /// Returns a ReadOnly IQueryable That match a specfic predicate
        /// </summary>
        /// <param name="predicate">the condition for retreving recrods from the database</param>
        IQueryable<TEntity> QueryWithMustFind(Expression<Func<TEntity, bool>> predicate, string notFoundMessage);

        /// <summary>
        /// Returns a ReadOnly IQueryable That contains all recrod in one table
        /// </summary>        
        IQueryable<TEntity> Query();
    }
}