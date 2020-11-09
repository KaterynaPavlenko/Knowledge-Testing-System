using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IQuestionService
    {
        /// <summary>
        ///     Getting all  questions
        /// </summary>
        /// <returns> Question collection</returns>
        IEnumerable<QuestionDTO> GetAll();

        /// <summary>
        ///     Getting  Question by id
        /// </summary>
        /// <param name="id"> Question id</param>
        /// <returns>Question object</returns>
        QuestionDTO GetById(int id);

        /// <summary>
        ///     Add a Question using a Question Object
        /// </summary>
        /// <param name="question">Question object</param>
        void Create(QuestionDTO question);

        /// <summary>
        ///     Update a Question using a  Question Object
        /// </summary>
        /// <param name="question"> Question object</param>
        void Update(QuestionDTO question);

        /// <summary>
        ///     Delete a  Question by id
        /// </summary>
        /// <param name="id"> Question id</param>
        void Delete(int id);
        /// <summary>
        ///     Save a test 
        /// </summary>
        void Save();
    }
}