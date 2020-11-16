using System;
using System.Collections.Generic;
using System.Linq;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.BLL.Services;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnowledgeTestingSystem.Tests.ServiceTest
{
    [TestClass]
    public class StatisticServiceTest
    {
        private Mock<IRepository<UserStatistic>> _statisticRepository;
        private IUserStatisticService _statisticService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<UserStatistic> statistics;

        [TestInitialize]
        public void SetUp()
        {
            statistics = new List<UserStatistic>
            {
               new UserStatistic
                {
                Id = 1,
                Mark = 1,
                CountCorrectAnswer = 1,
                DateTimeEnd = DateTime.Now,
                DateTimeStart = DateTime.Now,
                UserEntityId = "1",
                Test = new Test(),
                UserEntity = new UserEntity()
            },
                new UserStatistic
               {
               Id = 2,
               Mark = 2,
               CountCorrectAnswer = 2,
               DateTimeStart = DateTime.Now,
               DateTimeEnd = DateTime.Today,
               UserEntityId = "2",
               Test = new Test(),
               UserEntity = new UserEntity()
            },
               new UserStatistic
                {
                Id = 3,
                Mark = 3,
                CountCorrectAnswer = 3,
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Today,
                UserEntityId = "3",
                Test = new Test(),
                UserEntity = new UserEntity()
            }
        };
            // Create a new mock of the repository
            _statisticRepository = new Mock<IRepository<UserStatistic>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.UserStatistic.GetAll( "Test , UserEntity")).Returns(statistics);
            _statisticRepository.Setup(x => x.GetAll("Test , UserEntity"))
                .Returns(statistics);
            // Create the service and inject the repository into the service
            _statisticService = new UserStatisticService(_unitOfWork.Object);
        }

        [TestMethod]
        public void StatisticService_Get_All_Statistic()
        {
            // Act
            var actual = _statisticService.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count(), "The statistic count is not correct");
        }

        [TestMethod]
        public void StatisticService_Can_GetById_Valid_Statistic()
        {
            //Arrange
            var expectedStatistic= new UserStatistic
            {
                Id = 1,
                Mark = 1,
                CountCorrectAnswer = 1,
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Today,
                UserEntityId = "1"
            };

            _unitOfWork.Setup(m => m.UserStatistic.GetById(expectedStatistic.Id)).Returns(expectedStatistic);
            // Act
            var actual = _statisticService.GetById(expectedStatistic.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedStatistic.Id, actual.Id); //assert that actual result was as expected
        }

        [TestMethod]
        public void StatisticService_Can_Update_Statistic()
        {
            //Arrange
            var statisticDto = new UserStatisticDTO
            {
                Id = 3,
                Mark = 5,
            };
            _unitOfWork.Setup(m => m.UserStatistic.GetById(statisticDto.Id)).Returns(statistics.FirstOrDefault(x => x.Id == statisticDto.Id));
            _unitOfWork.Setup(m => m.UserStatistic.Update(It.IsAny<UserStatistic>()));
            // Act
            _statisticService.Update(statisticDto);
            _statisticService.Save();

            // Assert
            _unitOfWork.Verify(v => v.UserStatistic.Update(It.IsAny<UserStatistic>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void StatisticService_Can_Delete_Statistic()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.UserStatistic.Delete(DeletedID));
            _unitOfWork.Setup(m => m.UserStatistic.GetById(DeletedID)).Returns(statistics.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _statisticService.Delete(DeletedID);
            _statisticService.Save();
            // Assert
            _unitOfWork.Verify(v => v.UserStatistic.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void StatisticService_Can_Create_Statistic()
        {
            //Arrange
            var statisticDto = new UserStatisticDTO
            {
                Id = 3,
                Mark = 5,
            };
            _unitOfWork.Setup(x => x.UserStatistic.Create(It.IsAny<UserStatistic>()));
            _unitOfWork.Setup(m => m.UserStatistic.GetById(statisticDto.Id)).Returns(statistics.FirstOrDefault(x => x.Id == statisticDto.Id));
            // Act
            _statisticService.Create(statisticDto);
            _statisticService.Save();
            // Assert
            _unitOfWork.Verify(v => v.UserStatistic.Create(It.IsAny<UserStatistic>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

    }
}