using Voting_API.Database.Domain;

namespace Voting_API.Database.Repositories
{
    /// <summary>
    /// The base repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
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
        /// Update the entities in the storage
        /// </summary>
        /// <param name="entities"></param>
        void UpdateMany(IList<TEntity> entities);

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