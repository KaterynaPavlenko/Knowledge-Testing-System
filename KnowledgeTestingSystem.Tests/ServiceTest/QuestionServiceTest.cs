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
    public class QuestionServiceTest
    {
        private Mock<IRepository<Question>> _questionRepository;
        private IQuestionService _questionService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<Question> questions;

        [TestInitialize]
        public void SetUp()
        {
            questions = new List<Question>
            {
                 new Question
                {
                Id = 1,
                Text = "Question 1"
            },
           new Question
            {
                Id = 2,
                Text = "Question 2"
            },
                 new Question
            {
                Id = 3,
                Text = "Question 3"
            }
        };
            // Create a new mock of the repository
            _questionRepository = new Mock<IRepository<Question>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.Questions.GetAll("")).Returns(questions);
            _questionRepository.Setup(x => x.GetAll(""))
                .Returns(questions);
            // Create the service and inject the repository into the service
            _questionService = new QuestionService(_unitOfWork.Object);
        }

        [TestMethod]
        public void QuestionService_Get_All_Question()
        {
            // Act
            var actual = _questionService.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count(), "The question count is not correct");
        }

        [TestMethod]
        public void QuestionService_Can_GetById_Valid_Question()
        {
            //Arrange
            var expectedQuestion = new Question
            {
                Id = 1,
                Text = "Question 1"
            };

            _unitOfWork.Setup(m => m.Questions.GetById(expectedQuestion.Id)).Returns(expectedQuestion);
            // Act
            var actual = _questionService.GetById(expectedQuestion.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedQuestion.Id, actual.Id); //assert that actual result was as expected
        }

        [TestMethod]
        public void QuestionService_Can_Update_Question()
        {
            //Arrange
            var questionDto = new QuestionDTO
            {
                Id = 1,
                Text = "Question 1"
            };
            _unitOfWork.Setup(m => m.Questions.GetById(questionDto.Id)).Returns(questions.FirstOrDefault(x => x.Id == questionDto.Id));
            _unitOfWork.Setup(m => m.Questions.Update(It.IsAny<Question>()));
            // Act
            _questionService.Update(questionDto);

            // Assert
            _unitOfWork.Verify(v => v.Questions.Update(It.IsAny<Question>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void QuestionService_Can_Delete_Question()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.Questions.Delete(DeletedID));
            _unitOfWork.Setup(m => m.Questions.GetById(DeletedID)).Returns(questions.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _questionService.Delete(DeletedID);
            // Assert
            _unitOfWork.Verify(v => v.Questions.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void QuestionService_Can_Create_Question()
        {
            //Arrange
            var questionDto = new QuestionDTO
            {
                Id = 4,
                Text = "Question 1",
            };
            _unitOfWork.Setup(x => x.Questions.Create(It.IsAny<Question>()));
            _unitOfWork.Setup(m => m.Questions.GetById(questionDto.Id)).Returns(questions.FirstOrDefault(x => x.Id == questionDto.Id));
            // Act
            _questionService.Create(questionDto);
            // Assert
            _unitOfWork.Verify(v => v.Questions.Create(It.IsAny<Question>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

    }
}