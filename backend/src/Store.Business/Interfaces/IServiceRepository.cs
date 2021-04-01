using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Business.Interfaces
{
    /// <summary>
    /// IRepository interface to support data operations
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public interface IServiceRepository<T> : IServiceReadRepository<T>
        where T : class
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Insert(T entity);

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entity">The entities.</param>
        List<T> Insert(List<T> entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Update(T entity);

        /// <summary>
        /// Updates the list of entities.
        /// </summary>
        /// <param name="entity">The list of entities.</param>
        List<T> Update(List<T> entity);

        /// <summary>
        /// Updates the specified entity id.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        T UpdateCustom(dynamic entity);

        /// <summary>
        /// Deletes the specified entity id.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        bool Delete(long entityId);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Deletes the specified entity id.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        Task DeleteAsync(long entityId);

    }
}
