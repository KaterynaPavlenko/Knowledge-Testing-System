﻿using System.Collections.Generic;
using System.Linq;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserStatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(UserStatisticDTO statistic)
        {
            _unitOfWork.UserStatistic.Create(new UserStatistic
            {
                UserEntityId = statistic.UserEntityId,
                CountCorrectAnswer = statistic.CountCorrectAnswer,
                Mark = statistic.Mark,
                DateTimeStart = statistic.DateTimeStart,
                DateTimeEnd = statistic.DateTimeEnd,
                TestId = statistic.TestId

            });
        }

        public void Delete(int id)
        {
            var statistic = _unitOfWork.UserStatistic.GetById(id);
            if (statistic == null)
                throw new ValidationException("Not found statistic", string.Empty);
            _unitOfWork.UserStatistic.Delete(id);
        }

        public IEnumerable<UserStatisticDTO> GetAll()
        {
            var entities = _unitOfWork.UserStatistic.GetAll(includeProperties:"Test , UserEntity");
            if (entities == null) throw new ValidationException("Not found statistic", string.Empty);
            var statisticsList = new List<UserStatisticDTO>();
            foreach (var statisticEntity in entities)
            {
                var statistic = new UserStatisticDTO
                {
                    Id = statisticEntity.Id,
                    CountCorrectAnswer = statisticEntity.CountCorrectAnswer,
                    DateTimeStart = statisticEntity.DateTimeStart,
                    DateTimeEnd = statisticEntity.DateTimeEnd,
                    Mark = statisticEntity.Mark,
                    UserEntityId = statisticEntity.UserEntityId,
                    TestId = statisticEntity.TestId

                };
                statisticsList.Add(statistic);
            }

            return statisticsList;
        }

        public UserStatisticDTO GetById(int id)
        {
            var statisticEntity = _unitOfWork.UserStatistic.GetById(id);
            if (statisticEntity == null) throw new ValidationException("Not found statistic", string.Empty);

            var statistic = new UserStatisticDTO
            {
                Id = statisticEntity.Id,
                Mark = statisticEntity.Mark,
                CountCorrectAnswer = statisticEntity.CountCorrectAnswer,
                DateTimeStart = statisticEntity.DateTimeStart,
                DateTimeEnd = statisticEntity.DateTimeEnd,
                UserEntityId = statisticEntity.UserEntityId,
                TestId = statisticEntity.TestId
            };
            return statistic;
        }

        public UserStatisticDTO Result(TestDTO test)
        {
            var statistic = new UserStatisticDTO
            {
                TestId = test.Id,
                CountCorrectAnswer = CountCorrectAnswer(test),
                Mark = Mark(test)
            };
            return statistic;
        }
        public void Update(UserStatisticDTO statisticDTO)
        {
            var foundStatistic = _unitOfWork.UserStatistic.GetById(statisticDTO.Id);
            if (foundStatistic == null)
                throw new ValidationException("Not found statistic for update", string.Empty);
            var statistic = new UserStatistic
            {
                Id = statisticDTO.Id,
                Mark = statisticDTO.Mark,
                CountCorrectAnswer = statisticDTO.CountCorrectAnswer,
                DateTimeStart = statisticDTO.DateTimeStart,
                DateTimeEnd = statisticDTO.DateTimeEnd,
                UserEntityId = statisticDTO.UserEntityId
            };
            _unitOfWork.UserStatistic.Update(statistic);
        }

        private int CountCorrectAnswer(TestDTO test)
        {
            int correctAnswer = 0;
            var questions = _unitOfWork.Tests.GetById(test.Id).Questions.ToList();
            foreach (var question in questions)
            {
                foreach (var answer in question.Answers)
                {
                    if (test.Question.First(x => x.Id == test.Id).Answer.First(x=>x.IsSelected).Id==answer.Id&&answer.IsCorrect)
                        correctAnswer++;
                }
            }
            return correctAnswer;
        }
        private int Mark(TestDTO test)
        {
            var correctAnswer = CountCorrectAnswer(test);
            var countAnswers = 0;
            foreach (var question in test.Question)
            {
                correctAnswer += question.Answer.Count();
            }

            return countAnswers - correctAnswer;
        }
        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}