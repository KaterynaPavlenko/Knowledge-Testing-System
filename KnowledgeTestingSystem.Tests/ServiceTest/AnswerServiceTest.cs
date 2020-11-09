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
    public class AnswerServiceTest
    {
        private Mock<IRepository<Answer>> _answerRepository;
        private IAnswerService _answerService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<Answer> answers;

        [TestInitialize]
        public void SetUp()
        {
            answers = new List<Answer>
            {
                 new Answer
                {
                Id = 1,
                Text = "Answer 1"
            },
           new Answer
            {
                Id = 2,
                Text = "Answer 2"
            },
                 new Answer()
            {
                Id = 3,
                Text = "Answer 3"
            }
        };
            // Create a new mock of the repository
            _answerRepository = new Mock<IRepository<Answer>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.Answers.GetAll()).Returns(answers);
            _answerRepository.Setup(x => x.GetAll())
                .Returns(answers);
            // Create the service and inject the repository into the service
            _answerService = new AnswerService(_unitOfWork.Object);
        }

        [TestMethod]
        public void AnswerService_Get_All_Answer()
        {
            // Act
            var actual = _answerService.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count(), "The answer count is not correct");
        }

        [TestMethod]
        public void AnswerService_Can_GetById_Valid_Answer()
        {
            //Arrange
            var expectedAnswer = new Answer
            {
                Id = 1,
                Text = "Answer 1"
            };

            _unitOfWork.Setup(m => m.Answers.GetById(expectedAnswer.Id)).Returns(expectedAnswer);
            // Act
            var actual = _answerService.GetById(expectedAnswer.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedAnswer.Id, actual.Id); //assert that actual result was as expected
        }

        [TestMethod]
        public void AnswerService_Can_Update_Answer()
        {
            //Arrange
            var answerDto = new AnswerDTO
            {
                Id = 1,
                Text = "Answer 1"
            };
            _unitOfWork.Setup(m => m.Answers.GetById(answerDto.Id)).Returns(answers.FirstOrDefault(x => x.Id == answerDto.Id));
            _unitOfWork.Setup(m => m.Answers.Update(It.IsAny<Answer>()));
            // Act
            _answerService.Update(answerDto);
            _answerService.Save();

            // Assert
            _unitOfWork.Verify(v => v.Answers.Update(It.IsAny<Answer>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void AnswerService_Can_Delete_Answer()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.Answers.Delete(DeletedID));
            _unitOfWork.Setup(m => m.Answers.GetById(DeletedID)).Returns(answers.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _answerService.Delete(DeletedID);
            _answerService.Save();
            // Assert
            _unitOfWork.Verify(v => v.Answers.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void AnswerService_Can_Create_Answer()
        {
            //Arrange
            var answerDto = new AnswerDTO
            {
                Id = 4,
                Text = "Answer 1",
            };
            _unitOfWork.Setup(x => x.Answers.Create(It.IsAny<Answer>()));
            _unitOfWork.Setup(m => m.Answers.GetById(answerDto.Id)).Returns(answers.FirstOrDefault(x => x.Id == answerDto.Id));
            // Act
            _answerService.Create(answerDto);
            _answerService.Save();
            // Assert
            _unitOfWork.Verify(v => v.Answers.Create(It.IsAny<Answer>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

    }
}