using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(QuestionTypeDTO questionType)
        {
            _unitOfWork.QuestionTypes.Create(new QuestionType
            {
                Type = questionType.Type
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var questionsType = _unitOfWork.QuestionTypes.GetById(id);
            if (questionsType == null)
                throw new ValidationException("Not found question type", string.Empty);
            _unitOfWork.QuestionTypes.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<QuestionTypeDTO> GetAll()
        {
            var entities = _unitOfWork.QuestionTypes.GetAll();
            if (entities == null) throw new ValidationException("Not found questions type", string.Empty);
            var questionTypesList = new List<QuestionTypeDTO>();
            foreach (var questionEntity in entities)
            {
                var questionType = new QuestionTypeDTO
                {
                    Type = questionEntity.Type,
                    Id = questionEntity.Id
                };
                questionTypesList.Add(questionType);
            }

            return questionTypesList;
        }

        public QuestionTypeDTO GetById(int id)
        {
            var questionTypeEntity = _unitOfWork.QuestionTypes.GetById(id);
            if (questionTypeEntity == null) throw new ValidationException("Not found question type", string.Empty);

            var questionType = new QuestionTypeDTO
            {
                Id = questionTypeEntity.Id,
                Type = questionTypeEntity.Type
            };
            return questionType;
        }

        public void Update(QuestionTypeDTO questionType)
        {
            var foundQuestionType = _unitOfWork.QuestionTypes.GetById(questionType.Id);
            if (foundQuestionType == null)
                throw new ValidationException("Not found question type for update", string.Empty);
            var questionsType = new QuestionType
            {
                Id = questionType.Id,
                Type = questionType.Type
            };
            _unitOfWork.QuestionTypes.Update(questionsType);
            _unitOfWork.Save();
        }
    }
}