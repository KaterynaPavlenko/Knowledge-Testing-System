using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.BLL.Services;
using Ninject.Modules;

namespace KnowledgeTestingSystem.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestService>().To<TestService>();
            Bind<IUserStatisticService>().To<UserStatisticService>();
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IQuestionTypeService>().To<QuestionTypeService>();
            Bind<IThemeOfTestService>().To<ThemeOfTestService>();
            Bind<IQuestionService>().To<QuestionService>();
        }
    }
}