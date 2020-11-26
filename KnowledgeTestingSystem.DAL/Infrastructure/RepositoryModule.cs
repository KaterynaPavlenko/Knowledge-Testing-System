using KnowledgeTestingSystem.DAL.Repositories;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;
using Ninject.Modules;

namespace KnowledgeTestingSystem.DAL.Infrastructure
{
    public class RepositoryModule : NinjectModule
    {
        private readonly string connectionString;

        public RepositoryModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}