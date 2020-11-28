using KnowledgeTestingSystem.DAL.Entity;

namespace KnowledgeTestingSystem.DAL.Repositories.Interfaces
{
    public interface IThemeOfTestRepository : IRepository<ThemeOfTest>
    {
        /// <summary>
        ///     Get ThemeOfTest entity by theme
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <returns>ThemeOfTest entity</returns>
        ThemeOfTest GetByTheme(string theme);
    }
}