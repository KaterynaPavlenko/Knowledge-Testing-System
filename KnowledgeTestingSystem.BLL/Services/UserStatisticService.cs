using System.Collections.Generic;
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
                PercentCorrectAnswer = statistic.PercentCorrectAnswer,
                DateTimeStart = statistic.DateTimeStart,
                DateTimeEnd = statistic.DateTimeEnd,
                TestId = statistic.TestId
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var statistic = _unitOfWork.UserStatistic.GetById(id);
            if (statistic == null)
                throw new ValidationException("Not found statistic", string.Empty);
            _unitOfWork.UserStatistic.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<UserStatisticDTO> GetAll()
        {
            var entities = _unitOfWork.UserStatistic.GetAll("Test , UserEntity");
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
                    PercentCorrectAnswer = statisticEntity.PercentCorrectAnswer,
                    UserEntityId = statisticEntity.UserEntityId,
                    TestId = statisticEntity.TestId,
                    Test = statisticEntity.Test.Name

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
                PercentCorrectAnswer = statisticEntity.PercentCorrectAnswer,
                CountCorrectAnswer = statisticEntity.CountCorrectAnswer,
                DateTimeStart = statisticEntity.DateTimeStart,
                DateTimeEnd = statisticEntity.DateTimeEnd,
                UserEntityId = statisticEntity.UserEntityId,
                TestId = statisticEntity.TestId
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
                PercentCorrectAnswer = statisticDTO.PercentCorrectAnswer,
                CountCorrectAnswer = statisticDTO.CountCorrectAnswer,
                DateTimeStart = statisticDTO.DateTimeStart,
                DateTimeEnd = statisticDTO.DateTimeEnd,
                UserEntityId = statisticDTO.UserEntityId
            };
            _unitOfWork.UserStatistic.Update(statistic);
            _unitOfWork.Save();
        }
    }
}