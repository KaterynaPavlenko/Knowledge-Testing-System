using System.Linq;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        /// <summary>
        ///     Initializes a new instance of the TestRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public TestRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }

        public Test GetByName(string testName)
        {
            return GetAll().FirstOrDefault(e => e.Name == testName);
        }
    }
}