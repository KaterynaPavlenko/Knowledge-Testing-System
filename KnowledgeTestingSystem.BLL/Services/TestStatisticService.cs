using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class TestStatisticService : ITestStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestStatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            var testStatistic = _unitOfWork.TestStatistic.GetById(id);
            if (testStatistic == null)
                throw new ValidationException("Not found test statistic", string.Empty);
            _unitOfWork.TestStatistic.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<TestStatisticDTO> GetAll()
        {
            var entities = _unitOfWork.TestStatistic.GetAll("Test");
            if (entities == null) throw new ValidationException("Not found test statistic", string.Empty);
            var testStatisticList = new List<TestStatisticDTO>();
            foreach (var testStatisticEntity in entities)
            {
                var testStatistic = new TestStatisticDTO
                {
                    Id = testStatisticEntity.Id,
                    Count = testStatisticEntity.Count,
                    AverageTime = testStatisticEntity.AverageTime,
                    TestId = testStatisticEntity.TestId,
                    Test = testStatisticEntity.Test.Name,
                    AveragePercentCorrectAnswer = testStatisticEntity.AveragePercentCorrectAnswer,
                    TimeLastUpdateStatistic = testStatisticEntity.TimeLastUpdateStatistic

                };
                testStatisticList.Add(testStatistic);
            }

            return testStatisticList;
        }

        public TestStatisticDTO GetById(int id)
        {
            var testStatistic = _unitOfWork.TestStatistic.GetById(id);
            if (testStatistic == null) throw new ValidationException("Not found test statistic", string.Empty);
            var testStatisticDto = new TestStatisticDTO
            {
                Id = testStatistic.Id,
                Count = testStatistic.Count,
                AverageTime = testStatistic.AverageTime,
                TestId = testStatistic.TestId,
                Test = testStatistic.Test.Name,
                AveragePercentCorrectAnswer = testStatistic.AveragePercentCorrectAnswer,
                TimeLastUpdateStatistic = testStatistic.TimeLastUpdateStatistic
            };
            return testStatisticDto;
        }

        public void Update(int testId)
        {
            var test = _unitOfWork.Tests.GetById(testId);
            var userStatistics = _unitOfWork.UserStatistic.GetAll().Where(e => e.TestId == testId).ToList();
            if (userStatistics.Count != 0)
            {
                TimeSpan averageTime = TimeSpan.Zero;
                int averagePercentCorrectAnswer = 0;
                foreach (var userStatistic in userStatistics)
                {
                    averageTime += userStatistic.UserTestTime;
                    averagePercentCorrectAnswer += userStatistic.PercentCorrectAnswer;
                }
                TimeSpan avg = new TimeSpan(averageTime.Ticks / userStatistics.Count);
                averagePercentCorrectAnswer = averagePercentCorrectAnswer / userStatistics.Count;
                _unitOfWork.TestStatistic.Update(new TestStatistic
                {
                    TestId = testId,
                    Count = userStatistics.Count,
                    AverageTime = avg,
                    AveragePercentCorrectAnswer = averagePercentCorrectAnswer,
                    TimeLastUpdateStatistic = DateTime.Now
                });
                _unitOfWork.Save();
            }
        }
    }
}

