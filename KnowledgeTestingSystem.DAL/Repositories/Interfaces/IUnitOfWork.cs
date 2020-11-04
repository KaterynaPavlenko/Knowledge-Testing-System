using System;

namespace KnowledgeTestingSystem.DAL.Repositories.Interfaces
{
    /// <summary>
    ///     Defines the interface for  unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Gets the specified repository for the Answer
        /// </summary>
        IAnswerRepository Answers { get; }

        /// <summary>
        ///     Gets the specified repository for the Question
        /// </summary>
        IQuestionRepository Questions { get; }

        /// <summary>
        ///     Gets the specified repository for the QuestionType
        /// </summary>
        IQuestionTypeRepository QuestionTypes { get; }

        /// <summary>
        ///     Gets the specified repository for the Statistic
        /// </summary>
        IStatisticRepository Statistics { get; }

        /// <summary>
        ///     Gets the specified repository for the Test
        /// </summary>
        ITestRepository Tests { get; }

        /// <summary>
        ///     Gets the specified repository for the ThemeOfTest
        /// </summary>
        IThemeOfTestRepository ThemesOfTest { get; }

        /// <summary>
        ///     Saves all updates to the data source
        /// </summary>
        void Save();
    }
}