using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(QuestionDTO question)
        {
            _unitOfWork.Questions.Create(new Question
            {
                Image = question.Image,
                Text = question.Text,
                QuestionsTypesId = question.QuestionsTypesId
            });
        }

        public void Delete(int id)
        {
            var question = _unitOfWork.Questions.GetById(id);
            if (question == null)
                throw new ValidationException("Not found question", string.Empty);
            _unitOfWork.Questions.Delete(id);
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            var entities = _unitOfWork.Questions.GetAll();
            if (entities == null) throw new ValidationException("Not found questions", string.Empty);
            var questions = new List<QuestionDTO>();
            foreach (var questionEntity in entities)
            {
                var answer = new QuestionDTO
                {
                    Text = questionEntity.Text,
                    Id = questionEntity.Id,
                    Image = questionEntity.Image,
                    QuestionsTypesId = questionEntity.QuestionsTypesId,
                    TestId = questionEntity.TestId
                };
                questions.Add(answer);
            }

            return questions;
        }

        public QuestionDTO GetById(int id)
        {
            var questionEntity = _unitOfWork.Questions.GetById(id);
            if (questionEntity == null) throw new ValidationException("Not found question", string.Empty);

            var question = new QuestionDTO
            {
                Id = questionEntity.Id,
                Image = questionEntity.Image,
                QuestionsTypesId = questionEntity.QuestionsTypesId,
                Text = questionEntity.Text,
                TestId = questionEntity.TestId
            };
            return question;
        }

        public void Update(QuestionDTO questionDTO)
        {
            var foundQuestion = _unitOfWork.Questions.GetById(questionDTO.Id);
            if (foundQuestion == null)
                throw new ValidationException("Not found question for update", string.Empty);
            var question = new Question
            {
                Id = questionDTO.Id,
                Text = questionDTO.Text,
                QuestionsTypesId = questionDTO.QuestionsTypesId,
                Image = questionDTO.Image,
                TestId = questionDTO.TestId
            };
            _unitOfWork.Questions.Update(question);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}