using System.Collections.Generic;
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
            _unitOfWork.Tests.Create(new Test
            {
                ThemeOfTestId = test.ThemeOfTestId,
                Name = test.Name
            });
        }

        public void Delete(int id)
        {
            var test = _unitOfWork.Tests.GetById(id);
            if (test == null)
                throw new ValidationException("Not found test", string.Empty);
            _unitOfWork.Tests.Delete(id);
        }

        public IEnumerable<TestDTO> GetAll()
        {
            var entities = _unitOfWork.Tests.GetAll();
            if (entities == null) throw new ValidationException("Not found test", string.Empty);
            var testList = new List<TestDTO>();
            foreach (var testEntity in entities)
            {
                var test = new TestDTO
                {
                    Id = testEntity.Id,
                    ThemeOfTestId = testEntity.ThemeOfTestId,
                    Name = testEntity.Name
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
                ThemeOfTestId = testEntity.ThemeOfTestId
            };
            return test;
        }

        public void Update(TestDTO testDTO)
        {
            var foundTest = _unitOfWork.Tests.GetById(testDTO.Id);
            if (foundTest == null)
                throw new ValidationException("Not found test for update", string.Empty);
            var test = new Test
            {
                Id = testDTO.Id,
                Name = testDTO.Name,
                ThemeOfTestId = testDTO.ThemeOfTestId
            };
            _unitOfWork.Tests.Update(test);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}