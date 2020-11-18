using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(AnswerDTO answer)
        {
            _unitOfWork.Answers.Create(new Answer
            {
                Image = answer.Image,
                Text = answer.Text
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var answer = _unitOfWork.Answers.GetById(id);
            if (answer == null)
                throw new ValidationException("Not found answer", string.Empty);
            _unitOfWork.Answers.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<AnswerDTO> GetAll()
        {
            var entities = _unitOfWork.Answers.GetAll();
            if (entities == null) throw new ValidationException("Not found answers", string.Empty);
            var answers = new List<AnswerDTO>();
            foreach (var answerEntity in entities)
            {
                var answer = new AnswerDTO
                {
                    Text = answerEntity.Text,
                    Id = answerEntity.Id,
                    Image = answerEntity.Image,
                    QuestionId = answerEntity.QuestionId,
                    IsCorrect = answerEntity.IsCorrect
                };
                answers.Add(answer);
            }

            return answers;
        }

        public AnswerDTO GetById(int id)
        {
            var answerEntity = _unitOfWork.Answers.GetById(id);
            if (answerEntity == null) throw new ValidationException("Not found answer", string.Empty);

            var answer = new AnswerDTO
            {
                Id = answerEntity.Id,
                Image = answerEntity.Image,
                QuestionId = answerEntity.QuestionId,
                Text = answerEntity.Text,
                IsCorrect = answerEntity.IsCorrect
            };
            return answer;
        }

        public void Update(AnswerDTO answerDTO)
        {
            var foundAnswer = _unitOfWork.Answers.GetById(answerDTO.Id);
            if (foundAnswer == null)
                throw new ValidationException("Not found answer for update", string.Empty);
            var answer = new Answer
            {
                Id = answerDTO.Id,
                Text = answerDTO.Text,
                QuestionId = answerDTO.QuestionId,
                Image = answerDTO.Image,
                IsCorrect = answerDTO.IsCorrect
            };
            _unitOfWork.Answers.Update(answer);
            _unitOfWork.Save();
        }
    }
}