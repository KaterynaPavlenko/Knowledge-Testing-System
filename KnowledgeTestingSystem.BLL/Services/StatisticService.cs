using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(StatisticDTO statistic)
        {
            _unitOfWork.Statistics.Create(new Statistic
            {
                UserEntityId = statistic.UserEntityId,
                CountCorrectAnswer = statistic.CountCorrectAnswer,
                Mark = statistic.Mark,
                DateTimeStart = statistic.DateTimeStart,
                DateTimeEnd = statistic.DateTimeEnd
            });
        }

        public void Delete(int id)
        {
            var statistic = _unitOfWork.Statistics.GetById(id);
            if (statistic == null)
                throw new ValidationException("Not found statistic", string.Empty);
            _unitOfWork.Statistics.Delete(id);
        }

        public IEnumerable<StatisticDTO> GetAll()
        {
            var entities = _unitOfWork.Statistics.GetAll();
            if (entities == null) throw new ValidationException("Not found statistic", string.Empty);
            var statisticsList = new List<StatisticDTO>();
            foreach (var statisticEntity in entities)
            {
                var statistic = new StatisticDTO
                {
                    Id = statisticEntity.Id,
                    CountCorrectAnswer = statisticEntity.CountCorrectAnswer,
                    DateTimeStart = statisticEntity.DateTimeStart,
                    DateTimeEnd = statisticEntity.DateTimeEnd,
                    Mark = statisticEntity.Mark,
                    UserEntityId = statisticEntity.UserEntityId
                };
                statisticsList.Add(statistic);
            }

            return statisticsList;
        }

        public StatisticDTO GetById(int id)
        {
            var statisticEntity = _unitOfWork.Statistics.GetById(id);
            if (statisticEntity == null) throw new ValidationException("Not found statistic", string.Empty);

            var statistic = new StatisticDTO
            {
                Id = statisticEntity.Id,
                Mark = statisticEntity.Mark,
                CountCorrectAnswer = statisticEntity.CountCorrectAnswer,
                DateTimeStart = statisticEntity.DateTimeStart,
                DateTimeEnd = statisticEntity.DateTimeEnd,
                UserEntityId = statisticEntity.UserEntityId
            };
            return statistic;
        }

        public void Update(StatisticDTO statisticDTO)
        {
            var foundStatistic = _unitOfWork.Statistics.GetById(statisticDTO.Id);
            if (foundStatistic == null)
                throw new ValidationException("Not found statistic for update", string.Empty);
            var statistic = new Statistic
            {
                Id = statisticDTO.Id,
                Mark = statisticDTO.Mark,
                CountCorrectAnswer = statisticDTO.CountCorrectAnswer,
                DateTimeStart = statisticDTO.DateTimeStart,
                DateTimeEnd = statisticDTO.DateTimeEnd,
                UserEntityId = statisticDTO.UserEntityId
            };
            _unitOfWork.Statistics.Update(statistic);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}