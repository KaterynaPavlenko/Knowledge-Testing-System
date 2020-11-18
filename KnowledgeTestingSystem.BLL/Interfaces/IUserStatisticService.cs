using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IUserStatisticService
    {
        /// <summary>
        ///     Getting all  Statistic
        /// </summary>
        /// <returns> QuestionType collection</returns>
        IEnumerable<UserStatisticDTO> GetAll();

        /// <summary>
        ///     Getting  Statistic Type by id
        /// </summary>
        /// <param name="id"> Statistic id</param>
        /// <returns>Statistic object</returns>
        UserStatisticDTO GetById(int id);

        /// <summary>
        ///     Add a Statistic using a Statistic Object
        /// </summary>
        /// <param name="statistic">Statistic object</param>
        void Create(UserStatisticDTO statistic);

        /// <summary>
        ///     Update a Statistic using a  Statistic Object
        /// </summary>
        /// <param name="statistic"> Statistic object</param>
        void Update(UserStatisticDTO statistic);

        /// <summary>
        ///     Calculate Statistic
        /// </summary>
        /// <param name="test">Test object</param>
        /// <returns></returns>
        void Delete(int id);
    }
}