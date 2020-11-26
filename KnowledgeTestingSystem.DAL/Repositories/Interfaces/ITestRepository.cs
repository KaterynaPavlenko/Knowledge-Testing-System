using KnowledgeTestingSystem.DAL.Entity;

namespace KnowledgeTestingSystem.DAL.Repositories.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        /// <summary>
        ///     Get Test by name
        /// </summary>
        /// <returns>Test entity</returns>
         Test GetByName(string testName);
    }
}