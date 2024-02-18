using Domain;

namespace Infrastructure.Database.Repositories
{
    public interface IBaseRepository<TEntity>
            where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Inserts the entity into storage
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Update the entity in the storage
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the entity in storage
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Asynchronous get from storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Asynchronous get all entities of the type from storage
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();

        /// <summary>
        /// Asynchronous saving the changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();
    }
}
