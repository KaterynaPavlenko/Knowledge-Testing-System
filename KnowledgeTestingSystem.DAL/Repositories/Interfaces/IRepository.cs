using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Repositories.Interfaces
{
    /// <summary>
    ///     Generic repository interface provide all base needed methods
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        ///     Get all entity
        /// </summary>
        /// <returns>T collection</returns>
        IEnumerable<T> GetAll(string includeProperties = "");

        /// <summary>
        ///     Get entity by id
        /// </summary>
        /// <param name="id">T id</param>
        /// <returns>T entity</returns>
        T GetById(int id);

        /// <summary>
        ///     Add T entity
        /// </summary>
        /// <param name="item">T entity</param>
        void Create(T item);

        /// <summary>
        ///     Update T entity
        /// </summary>
        /// <param name="item">T entity</param>
        void Update(T item);

        /// <summary>
        ///     Delete T entity
        /// </summary>
        /// <param name="id"> T entity</param>
        void Delete(int id);
    }
}