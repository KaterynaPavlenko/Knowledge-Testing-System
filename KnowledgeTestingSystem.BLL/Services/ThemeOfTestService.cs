using System.Collections.Generic;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Infrastructure;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class ThemeOfTestService : IThemeOfTestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThemeOfTestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ThemeOfTestDTO test)
        {
            _unitOfWork.ThemesOfTest.Create(new ThemeOfTest
            {
                Theme = test.Theme
            });
        }

        public void Delete(int id)
        {
            var themeOfTest = _unitOfWork.ThemesOfTest.GetById(id);
            if (themeOfTest == null)
                throw new ValidationException("Not found theme of test", string.Empty);
            _unitOfWork.ThemesOfTest.Delete(id);
        }

        public IEnumerable<ThemeOfTestDTO> GetAll()
        {
            var entities = _unitOfWork.ThemesOfTest.GetAll();
            if (entities == null) throw new ValidationException("Not found themes of tests", string.Empty);
            var themeOfTestList = new List<ThemeOfTestDTO>();
            foreach (var themeOfTestEntity in entities)
            {
                var themeOfTest = new ThemeOfTestDTO
                {
                    Id = themeOfTestEntity.Id,
                    Theme = themeOfTestEntity.Theme
                };
                themeOfTestList.Add(themeOfTest);
            }

            return themeOfTestList;
        }

        public ThemeOfTestDTO GetById(int id)
        {
            var themeOfTestEntity = _unitOfWork.ThemesOfTest.GetById(id);
            if (themeOfTestEntity == null) throw new ValidationException("Not found theme of test", string.Empty);

            var themeOfTest = new ThemeOfTestDTO
            {
                Id = themeOfTestEntity.Id,
                Theme = themeOfTestEntity.Theme
            };
            return themeOfTest;
        }

        public void Update(ThemeOfTestDTO themeOfTestDTO)
        {
            var foundThemeOfTest = _unitOfWork.ThemesOfTest.GetById(themeOfTestDTO.Id);
            if (foundThemeOfTest == null)
                throw new ValidationException("Not found theme of test for update", string.Empty);
            var themeOfTest = new ThemeOfTest
            {
                Id = themeOfTestDTO.Id,
                Theme = themeOfTestDTO.Theme
            };
            _unitOfWork.ThemesOfTest.Update(themeOfTest);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}