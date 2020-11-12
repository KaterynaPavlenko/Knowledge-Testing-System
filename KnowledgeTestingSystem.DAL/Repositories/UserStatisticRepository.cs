using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class UserStatisticRepository : Repository<UserStatistic>, IUserStatisticRepository
    {
        /// <summary>
        ///     Initializes a new instance of the StatisticRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public UserStatisticRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }
    }
}