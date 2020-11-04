using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        /// <summary>
        ///     Initializes a new instance of the QuestionRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public QuestionRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }
    }
}