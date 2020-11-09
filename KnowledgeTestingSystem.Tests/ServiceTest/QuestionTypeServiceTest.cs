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
    public class QuestionTypeServiceTest
    {
        private Mock<IRepository<QuestionType>> _questionTypeRepository;
        private IQuestionTypeService _questionTypeService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<QuestionType> questionTypes;

        [TestInitialize]
        public void SetUp()
        {
            questionTypes = new List<QuestionType>
            {
                 new QuestionType
                {
                Id = 1,
                Type = "QuestionType 1"
            },
           new QuestionType
            {
                Id = 2,
                Type = "QuestionType 2"
            },
                 new QuestionType
            {
                Id = 3,
                Type = "QuestionType 3"
            }
        };
            // Create a new mock of the repository
            _questionTypeRepository = new Mock<IRepository<QuestionType>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.QuestionTypes.GetAll()).Returns(questionTypes);
            _questionTypeRepository.Setup(x => x.GetAll())
                .Returns(questionTypes);
            // Create the service and inject the repository into the service
            _questionTypeService = new QuestionTypeService(_unitOfWork.Object);
        }

        [TestMethod]
        public void QuestionTypeService_Get_All_QuestionTypes()
        {
            // Act
            var actual = _questionTypeService.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count(), "The question types count is not correct");
        }

        [TestMethod]
        public void QuestionTypeService_Can_GetById_Valid_QuestionType()
        {
            //Arrange
            var expectedQuestionType= new QuestionType
            {
                Id = 1,
                Type = "QuestionType 1"
            };

            _unitOfWork.Setup(m => m.QuestionTypes.GetById(expectedQuestionType.Id)).Returns(expectedQuestionType);
            // Act
            var actual = _questionTypeService.GetById(expectedQuestionType.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedQuestionType.Id, actual.Id); //assert that actual result was as expected
        }

        [TestMethod]
        public void QuestionTypeService_Can_Update_QuestionType()
        {
            //Arrange
            var questionTypeDto = new QuestionTypeDTO
            {
                Id = 1,
                Type = "QuestionType 1"
            };
            _unitOfWork.Setup(m => m.QuestionTypes.GetById(questionTypeDto.Id)).Returns(questionTypes.FirstOrDefault(x => x.Id == questionTypeDto.Id));
            _unitOfWork.Setup(m => m.QuestionTypes.Update(It.IsAny<QuestionType>()));
            // Act
            _questionTypeService.Update(questionTypeDto);
            _questionTypeService.Save();

            // Assert
            _unitOfWork.Verify(v => v.QuestionTypes.Update(It.IsAny<QuestionType>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void QuestionTypeService_Can_Delete_QuestionType()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.QuestionTypes.Delete(DeletedID));
            _unitOfWork.Setup(m => m.QuestionTypes.GetById(DeletedID)).Returns(questionTypes.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _questionTypeService.Delete(DeletedID);
            _questionTypeService.Save();
            // Assert
            _unitOfWork.Verify(v => v.QuestionTypes.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void QuestionTypeService_Can_Create_QuestionType()
        {
            //Arrange
            var questionTypeDto = new QuestionTypeDTO
            {
                Id = 4,
                Type = "QuestionType 1",
            };
            _unitOfWork.Setup(x => x.QuestionTypes.Create(It.IsAny<QuestionType>()));
            _unitOfWork.Setup(m => m.QuestionTypes.GetById(questionTypeDto.Id)).Returns(questionTypes.FirstOrDefault(x => x.Id == questionTypeDto.Id));
            // Act
            _questionTypeService.Create(questionTypeDto);
            _questionTypeService.Save();
            // Assert
            _unitOfWork.Verify(v => v.QuestionTypes.Create(It.IsAny<QuestionType>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

    }
}