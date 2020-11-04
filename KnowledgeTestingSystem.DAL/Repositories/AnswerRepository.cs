using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        /// <summary>
        ///     Initializes a new instance of the AnswerRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public AnswerRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }
    }
}