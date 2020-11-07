using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface ITestService
    {
        /// <summary>
        ///     Getting all Test
        /// </summary>
        /// <returns> Test collection</returns>
        IEnumerable<TestDTO> GetAll();

        /// <summary>
        ///     Getting Test Type by id
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Test object</returns>
        TestDTO GetById(int id);

        /// <summary>
        ///     Add a Test using a Test Object
        /// </summary>
        /// <param name="test">Test object</param>
        void Create(TestDTO test);

        /// <summary>
        ///     Update a test using a  test Object
        /// </summary>
        /// <param name="test"> Test object</param>
        void Update(TestDTO test);

        /// <summary>
        ///     Delete a test by id
        /// </summary>
        /// <param name="id"> Test id</param>
        void Delete(int id);
    }
}