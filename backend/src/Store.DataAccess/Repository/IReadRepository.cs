using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DataAccess.Repository
{
    /// <summary>
    /// IRepository interface to support data operations
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public interface IReadRepository<T>
        where T : class
    {
        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Searches for records depending on the predicate expression.
        /// </summary>
        /// <param name="predicate">Query expression</param>
        /// <returns>List of records</returns>
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a record by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Returns an Entity</returns>
        T GetById(long? id);

        /// <summary>
        /// Gets a record by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Returns an Entity</returns>
        T GetByName(string name);

        /// <summary>
        /// Get data by custom input
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        T GetByCustom(string json);

        /// <summary>
        /// Gets a record by filter.
        /// </summary>
        /// <param name="json">The filter param.</param>
        /// <returns>Returns List of Entity</returns>
        IEnumerable<T> GetListByCustom(string json);

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        Task<T> GetByCustomAsync(T result);

    }
}
