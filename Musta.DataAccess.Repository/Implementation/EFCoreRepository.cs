using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Musta.DataAccess.Repository.Abstract;


namespace Musta.DataAccess.Repository.Implementation
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _entities;
        public EFCoreRepository(DbContext ctx)
        {
            _ctx = ctx;
            _entities = _ctx.Set<TEntity>();
        }

        /// <summary>
        /// Adds a new record to the database , changes will not be save until you call SaveChanges method
        /// </summary>
        /// <param name="newEntity">the new recrod to add</param>
        public void Add(TEntity newEntity) => _entities.Add(newEntity);

        /// <summary>
        /// Removes a record from the database, changes will not be save until you call SaveChanges method
        /// </summary>
        /// <param name="entityToDelete">the record to be deleted</param>
        public void Delete(TEntity entityToDelete) => _entities.Remove(entityToDelete);

        /// <summary>
        /// Updates a record in the database, changes will not be save until you call SaveChanges method
        /// </summary>
        /// <param name="entityToUpdate">the record to be deleted</param>
        public EntityEntry Update(TEntity entityToUpdate) => _entities.Update(entityToUpdate);

        /// <summary>
        /// Save pending changes (add , update , delete)
        /// </summary>
        /// <returns>a boolean indicating in case the opreation performed any change to the database records (added new recrod , deleted or updated existing one )</returns>
        public bool SaveChanges() => _ctx.SaveChanges() > 1;





    }


}