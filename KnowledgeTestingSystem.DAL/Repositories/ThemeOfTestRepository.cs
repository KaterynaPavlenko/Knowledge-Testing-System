using System.Linq;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class ThemeOfTestRepository : Repository<ThemeOfTest>, IThemeOfTestRepository
    {
        /// <summary>
        ///     Initializes a new instance of the ThemeOfTestRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public ThemeOfTestRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }

        public ThemeOfTest GetByTheme(string theme)
        {
            return GetAll().FirstOrDefault(e => e.Theme == theme);
        }
    }
}