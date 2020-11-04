using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IThemeOfTestService
    {
        /// <summary>
        ///     Getting all ThemeOfTest
        /// </summary>
        /// <returns> ThemeOfTest collection</returns>
        IEnumerable<ThemeOfTestDTO> GetAll();

        /// <summary>
        ///     Getting ThemeOfTest Type by id
        /// </summary>
        /// <param name="id">ThemeOfTest id</param>
        /// <returns>ThemeOfTest object</returns>
        ThemeOfTestDTO GetById(int id);

        /// <summary>
        ///     Add a ThemeOfTest using a Test Object
        /// </summary>
        /// <param name="test">ThemeOfTest object</param>
        bool Create(ThemeOfTestDTO test);

        /// <summary>
        ///     Update a ThemeOfTest using a  test Object
        /// </summary>
        /// <param name="test"> ThemeOfTest object</param>
        bool Update(ThemeOfTestDTO test);

        /// <summary>
        ///     Delete a ThemeOfTest by id
        /// </summary>
        /// <param name="id"> ThemeOfTest id</param>
        bool Delete(int id);
    }
}