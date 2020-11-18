using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.BLL.Services;
using KnowledgeTestingSystem.DAL.Repositories;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace KnowledgeTestingSystem.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<ITestService>().To<TestService>().WithConstructorArgument(connectionString);
            Bind<IThemeOfTestService>().To<ThemeOfTestService>().WithConstructorArgument(connectionString);
            Bind<IAnswerService>().To<AnswerService>().WithConstructorArgument(connectionString);
            Bind<IQuestionService>().To<QuestionService>().WithConstructorArgument(connectionString);
            Bind<IQuestionTypeService>().To<QuestionTypeService>().WithConstructorArgument(connectionString);
            Bind<IUserStatisticService>().To<UserStatisticService>().WithConstructorArgument(connectionString);
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}