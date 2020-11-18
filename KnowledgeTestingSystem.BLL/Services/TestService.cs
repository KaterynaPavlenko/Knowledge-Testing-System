using System.Collections.Generic;
using System.Linq;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(TestDTO test)
        {
            ThemeOfTest theme;
            var foundTheme = _unitOfWork.ThemesOfTest.GetAll().FirstOrDefault(x => x.Theme == test.ThemeOfTest);
            if (foundTheme == null)
            {
                theme = new ThemeOfTest {Theme = test.ThemeOfTest};
                _unitOfWork.ThemesOfTest.Create(theme);
            }

            _unitOfWork.Tests.Create(new Test
            {
                ThemeOfTestId = test.ThemeOfTestId,
                Name = test.Name,
                CoverImage = test.CoverImage,
                TimeMinutes = test.TimeMinutes
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var test = _unitOfWork.Tests.GetById(id);
            if (test == null)
                throw new ValidationException("Not found test", string.Empty);
            _unitOfWork.Tests.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<TestDTO> GetAll()
        {
            var entities = _unitOfWork.Tests.GetAll("ThemeOfTest");
            if (entities == null) throw new ValidationException("Not found test", string.Empty);
            var testList = new List<TestDTO>();
            foreach (var testEntity in entities)
            {
                var test = new TestDTO
                {
                    Id = testEntity.Id,
                    ThemeOfTestId = testEntity.ThemeOfTestId,
                    Name = testEntity.Name,
                    TimeMinutes = testEntity.TimeMinutes,
                    CoverImage = testEntity.CoverImage,
                    ThemeOfTest = testEntity.ThemeOfTest.Theme
                };
                testList.Add(test);
            }

            return testList;
        }

        public TestDTO GetById(int id)
        {
            var testEntity = _unitOfWork.Tests.GetById(id);
            if (testEntity == null) throw new ValidationException("Not found test", string.Empty);
            var test = new TestDTO
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                ThemeOfTestId = testEntity.ThemeOfTestId,
                TimeMinutes = testEntity.TimeMinutes,
                CoverImage = testEntity.CoverImage,
                ThemeOfTest = testEntity.ThemeOfTest.Theme
            };
            return test;
        }

        public void Update(TestDTO testDTO)
        {
            var test = new Test
            {
                Id = testDTO.Id,
                Name = testDTO.Name,
                ThemeOfTestId = testDTO.ThemeOfTestId,
                TimeMinutes = testDTO.TimeMinutes,
                CoverImage = testDTO.CoverImage
            };
            _unitOfWork.Tests.Update(test);
            _unitOfWork.Save();
        }
    }
}