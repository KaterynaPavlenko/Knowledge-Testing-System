using System;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestingSystemDbContext _testingSystemDbContext;
        private IAnswerRepository _answerRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionTypeRepository _questionTypeRepository;
        private IUserStatisticRepository _statisticRepository;
        private ITestRepository _testRepository;
        private IThemeOfTestRepository _themeOfTestRepository;

        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the UnitOfWork
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public UnitOfWork(TestingSystemDbContext testingSystemDbContext)
        {
            _testingSystemDbContext = testingSystemDbContext;
        }


        /// <summary>
        ///     Gets the specified repository for the Answer
        /// </summary>
        public IAnswerRepository Answers
        {
            get
            {
                if (_answerRepository == null)
                    _answerRepository = new AnswerRepository(_testingSystemDbContext);
                return _answerRepository;
            }
        }

        /// <summary>
        ///     Gets the specified repository for the Question
        /// </summary>
        public IQuestionRepository Questions
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(_testingSystemDbContext);
                return _questionRepository;
            }
        }

        /// <summary>
        ///     Gets the specified repository for the QuestionType
        /// </summary>
        public IQuestionTypeRepository QuestionTypes
        {
            get
            {
                if (_questionTypeRepository == null)
                    _questionTypeRepository = new QuestionTypeRepository(_testingSystemDbContext);
                return _questionTypeRepository;
            }
        }

        /// <summary>
        ///     Gets the specified repository for the Test
        /// </summary>
        public ITestRepository Tests
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(_testingSystemDbContext);
                return _testRepository;
            }
        }

        /// <summary>
        ///     Gets the specified repository for the Statistic
        /// </summary>
        public IUserStatisticRepository UserStatistic
        {
            get
            {
                if (_statisticRepository == null)
                    _statisticRepository = new UserStatisticRepository(_testingSystemDbContext);
                return _statisticRepository;
            }
        }

        /// <summary>
        ///     Gets the specified repository for the ThemeOfTest
        /// </summary>
        public IThemeOfTestRepository ThemesOfTest
        {
            get
            {
                if (_themeOfTestRepository == null)
                    _themeOfTestRepository = new ThemeOfTestRepository(_testingSystemDbContext);
                return _themeOfTestRepository;
            }
        }


        /// <summary>
        ///     Saves all updates to the data source
        /// </summary>
        public void Save()
        {
            _testingSystemDbContext.SaveChanges();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) _testingSystemDbContext.Dispose();

                disposed = true;
            }
        }
    }
}