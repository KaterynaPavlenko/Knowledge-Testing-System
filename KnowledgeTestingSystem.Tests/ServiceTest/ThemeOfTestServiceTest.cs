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
    public class ThemeOfTestServiceTest
    {
        private Mock<IRepository<ThemeOfTest>> _themeOfTestRepository;
        private IThemeOfTestService _themeOfTestService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<ThemeOfTest> themesOfTestsList;

        [TestInitialize]
        public void SetUp()
        {
            themesOfTestsList = new List<ThemeOfTest>
            {
                 new ThemeOfTest
                {
                Id = 1,
                Theme = "ThemeOfTest 1"
            },
           new ThemeOfTest
            {
                Id = 2,
                Theme = "ThemeOfTest 2"
            },
                 new ThemeOfTest
            {
                Id = 3,
                Theme = "ThemeOfTest 3"
            }
        };
            // Create a new mock of the repository
            _themeOfTestRepository = new Mock<IRepository<ThemeOfTest>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.ThemesOfTest.GetAll()).Returns(themesOfTestsList);
            _themeOfTestRepository.Setup(x => x.GetAll())
                .Returns(themesOfTestsList);
            // Create the service and inject the repository into the service
            _themeOfTestService = new ThemeOfTestService(_unitOfWork.Object);
        }

        [TestMethod]
        public void ThemeOfTestService_Get_All_Themes()
        {
            // Act
            var actual = _themeOfTestService.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count(), "The themes of tests count is not correct");
        }

        [TestMethod]
        public void ThemeOfTestService_Can_GetById_Valid_Themes()
        {
            //Arrange
            var expectedThemeOfTest = new ThemeOfTest
            {
                Id = 1,
                Theme = "ThemeOfTest 1"
            };

            _unitOfWork.Setup(m => m.ThemesOfTest.GetById(expectedThemeOfTest.Id)).Returns(expectedThemeOfTest);
            // Act
            var actual = _themeOfTestService.GetById(expectedThemeOfTest.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedThemeOfTest.Id, actual.Id); //assert that actual result was as expected
        }

        [TestMethod]
        public void ThemeOfTestService_Can_Update_Themes()
        {
            //Arrange
            var themeOfTestDto = new ThemeOfTestDTO
            {
                Id = 1,
                Theme = "ThemeOfTest 1"
            };
            _unitOfWork.Setup(m => m.ThemesOfTest.GetById(themeOfTestDto.Id)).Returns(themesOfTestsList.FirstOrDefault(x => x.Id == themeOfTestDto.Id));
            _unitOfWork.Setup(m => m.ThemesOfTest.Update(It.IsAny<ThemeOfTest>()));
            // Act
            _themeOfTestService.Update(themeOfTestDto);
            _themeOfTestService.Save();

            // Assert
            _unitOfWork.Verify(v => v.ThemesOfTest.Update(It.IsAny<ThemeOfTest>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void ThemeOfTestService_Can_Delete_Themes()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.ThemesOfTest.Delete(DeletedID));
            _unitOfWork.Setup(m => m.ThemesOfTest.GetById(DeletedID)).Returns(themesOfTestsList.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _themeOfTestService.Delete(DeletedID);
            _themeOfTestService.Save();
            // Assert
            _unitOfWork.Verify(v => v.ThemesOfTest.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

        [TestMethod]
        public void ThemeOfTestService_Can_Create_Themes()
        {
            //Arrange
            var themeOfTestDto = new ThemeOfTestDTO
            {
                Id = 4,
                Theme = "ThemeOfTest 1",
            };
            _unitOfWork.Setup(x => x.ThemesOfTest.Create(It.IsAny<ThemeOfTest>()));
            _unitOfWork.Setup(m => m.ThemesOfTest.GetById(themeOfTestDto.Id)).Returns(themesOfTestsList.FirstOrDefault(x => x.Id == themeOfTestDto.Id));
            // Act
            _themeOfTestService.Create(themeOfTestDto);
            _themeOfTestService.Save();
            // Assert
            _unitOfWork.Verify(v => v.ThemesOfTest.Create(It.IsAny<ThemeOfTest>()), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }

    }
}