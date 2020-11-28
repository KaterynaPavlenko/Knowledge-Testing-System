using System.Collections.Generic;
using System.Linq;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.BLL.Services;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnowledgeTestingSystem.Tests.ServiceTest
{
    [TestClass]
    public class TestServiceTest
    {
        private Mock<IRepository<Test>> _testRepository;
        private ITestService _testService;
        private Mock<IRepository<ThemeOfTest>> _themeOfTestRepository;
        private IThemeOfTestService _themeOfTestService;
        private Mock<IUnitOfWork> _unitOfWork;
        private List<Test> tests;
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
            tests = new List<Test>
            {
                new Test
                {
                    Id = 1,
                    Name = "Test_1",
                    ThemeOfTestId = 1,
                    ThemeOfTest = new ThemeOfTest()
                },
                new Test
                {
                    Id = 2,
                    Name = "Test_2",
                    ThemeOfTestId = 1,
                    ThemeOfTest = new ThemeOfTest()
                },
                new Test
                {
                    Id = 3,
                    Name = "Test_3",
                    ThemeOfTestId = 2,
                    ThemeOfTest = new ThemeOfTest()
                }
            };
            // Create a new mock of the repository
            _testRepository = new Mock<IRepository<Test>>();
            _themeOfTestRepository = new Mock<IRepository<ThemeOfTest>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            // Set up the mock for the repository
            _unitOfWork.Setup(x => x.Tests.GetAll("ThemeOfTest")).Returns(tests);
            _testRepository.Setup(x => x.GetAll("ThemeOfTest")).Returns(tests);
            _themeOfTestRepository.Setup(x => x.GetAll("")).Returns(themesOfTestsList);
            // Create the service and inject the repository into the service
            _testService = new TestService(_unitOfWork.Object);
            _themeOfTestService = new ThemeOfTestService(_unitOfWork.Object);
        }

        [TestMethod]
        public void TestService_Get_All_Tests()
        {
            // Act
            var testActual = _testService.GetAll();

            // Assert
            Assert.AreEqual(3, testActual.Count(), "The test count is not correct");
        }

        [TestMethod]
        public void TestService_Can_GetById_Valid_Test()
        {
            //Arrange
            var expectedTest = new Test
            {
                Id = 1,
                Name = "Test_1",
                ThemeOfTestId = 1
            };

            _unitOfWork.Setup(m => m.Tests.GetById(expectedTest.Id)).Returns(expectedTest);
            // Act
            var actual = _testService.GetById(expectedTest.Id);

            //Assert
            _unitOfWork.Verify(); //verify that GetByID was called based on setup.
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(expectedTest.Id, actual.Id); //assert that actual result was as expected
        }


        [TestMethod]
        public void TestService_Can_Delete_Test()
        {
            //Arrange
            var DeletedID = 1;
            _unitOfWork.Setup(m => m.Tests.Delete(DeletedID));
            _unitOfWork.Setup(m => m.Tests.GetById(DeletedID)).Returns(tests.FirstOrDefault(x => x.Id == DeletedID));
            // Act
            _testService.Delete(DeletedID);
            // Assert
            _unitOfWork.Verify(v => v.Tests.Delete(DeletedID), Times.Once());
            _unitOfWork.Verify(x => x.Save(), Times.Once());
        }
    }
}