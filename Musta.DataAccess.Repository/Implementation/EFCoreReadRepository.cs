using Microsoft.EntityFrameworkCore;
using Musta.DataAccess.Repository.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Musta.DataAccess.Repository.Implementation
{
    public class EFCoreReadRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _ctx;
        private readonly IQueryable<TEntity> _entities;
        private const string _notFoundMessage = "Can't find any records matching your condition";

        public EFCoreReadRepository(DbContext ctx)
        {
            _ctx = ctx;
            _entities = _ctx.Set<TEntity>().AsNoTracking();
        }


        /// <summary>
        /// Returns a ReadOnly IQueryable That match a specfic predicate
        /// </summary>
        /// <param name="predicate">the condition for retreving recrods from the database</param>
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate) => _entities.Where(predicate);


        /// <summary>
        /// Returns a ReadOnly IQueryable That match a specfic predicate
        /// </summary>
        /// <param name="predicate">the condition for retreving recrods from the database</param>
        public IQueryable<TEntity> QueryWithMustFind(Expression<Func<TEntity, bool>> predicate,string notFoundMessage = _notFoundMessage) 
        {
            var result = _entities.Where(predicate);
            return result.Any() ? result : throw new Exception(_notFoundMessage);
        }



        /// <summary>
        /// Returns a ReadOnly IQueryable That contains all recrod in one table
        /// </summary>        
        public IQueryable<TEntity> Query() => _entities;
    }
}
