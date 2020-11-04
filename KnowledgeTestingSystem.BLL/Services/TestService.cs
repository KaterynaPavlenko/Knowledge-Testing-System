using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.BLL.Services
{
    public class TestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}