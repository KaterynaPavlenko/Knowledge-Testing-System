using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.BLL.Interfaces
{
    public interface IQuestionTypeService
    {
        /// <summary>
        ///     Getting all  QuestionTypes
        /// </summary>
        /// <returns> QuestionType collection</returns>
        IEnumerable<QuestionTypeDTO> GetAll();

        /// <summary>
        ///     Getting  Question Type by id
        /// </summary>
        /// <param name="id"> QuestionType id</param>
        /// <returns>QuestionType object</returns>
        QuestionTypeDTO GetById(int id);

        /// <summary>
        ///     Add a QuestionType using a QuestionType Object
        /// </summary>
        /// <param name="questionType">Question object</param>
        void Create(QuestionTypeDTO questionType);

        /// <summary>
        ///     Update a QuestionType using a  Question Object
        /// </summary>
        /// <param name="questionType"> QuestionType object</param>
        void Update(QuestionTypeDTO questionType);

        /// <summary>
        ///     Delete a  QuestionType by id
        /// </summary>
        /// <param name="id"> QuestionType id</param>
        void Delete(int id);
    }
}