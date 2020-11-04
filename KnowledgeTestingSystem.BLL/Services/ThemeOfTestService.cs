using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class ThemeOfTestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ThemeOfTestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}