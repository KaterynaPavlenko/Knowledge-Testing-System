using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class QuestionTypeRepository : Repository<QuestionsType>, IQuestionTypeRepository
    {
        /// <summary>
        ///     Initializes a new instance of the QuestionTypeRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public QuestionTypeRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }
    }
}