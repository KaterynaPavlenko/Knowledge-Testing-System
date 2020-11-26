using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface ITestStatisticService
    {
        /// <summary>
        ///     Getting all TestStatistic
        /// </summary>
        /// <returns> TestStatistic collection</returns>
        IEnumerable<TestStatisticDTO> GetAll();

        /// <summary>
        ///     Getting TestStatistic by id
        /// </summary>
        /// <param name="id">TestStatistic id</param>
        /// <returns>TestStatistic object</returns>
        TestStatisticDTO GetById(int id);


        /// <summary>
        ///     Update a TestStatistic using a Test Id
        /// </summary>
        /// <param name="testId"> Test id</param>
        void Update( int testId);

        /// <summary>
        ///     Delete a TestStatistic by id
        /// </summary>
        /// <param name="id"> TestStatistic id</param>
        void Delete(int id);
    }
}
