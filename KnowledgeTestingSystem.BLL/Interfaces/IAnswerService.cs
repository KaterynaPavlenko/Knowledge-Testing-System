using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IAnswerService
    {
        /// <summary>
        ///     Getting all  Answers
        /// </summary>
        /// <returns> Answer collection</returns>
        IEnumerable<AnswerDTO> GetAll();

        /// <summary>
        ///     Getting  Answer by id
        /// </summary>
        /// <param name="id"> Answer id</param>
        /// <returns>Booking object</returns>
        AnswerDTO GetById(int id);

        /// <summary>
        ///     Add a booking using a Booking Object
        /// </summary>
        /// <param name="answer">Booking object</param>
        bool Create(AnswerDTO answer);

        /// <summary>
        ///     Update an  Answer using a  Answer Object
        /// </summary>
        /// <param name="answer"> Answer object</param>
        bool Update(AnswerDTO answer);

        /// <summary>
        ///     Delete a  Answer by id
        /// </summary>
        /// <param name="id"> Answer id</param>
        bool Delete(int id);
    }
}