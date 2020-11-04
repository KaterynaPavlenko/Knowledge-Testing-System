using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IStatisticService
    {
        /// <summary>
        ///     Getting all  Statistic
        /// </summary>
        /// <returns> QuestionType collection</returns>
        IEnumerable<StatisticDTO> GetAll();

        /// <summary>
        ///     Getting  Statistic Type by id
        /// </summary>
        /// <param name="id"> Statistic id</param>
        /// <returns>Statistic object</returns>
        StatisticDTO GetById(int id);

        /// <summary>
        ///     Add a Statistic using a Statistic Object
        /// </summary>
        /// <param name="statistic">Statistic object</param>
        bool Create(StatisticDTO statistic);

        /// <summary>
        ///     Update a Statistic using a  Statistic Object
        /// </summary>
        /// <param name="statistic"> Statistic object</param>
        bool Update(StatisticDTO statistic);

        /// <summary>
        ///     Delete a Statistic by id
        /// </summary>
        /// <param name="id"> Statistic id</param>
        bool Delete(int id);
    }
}