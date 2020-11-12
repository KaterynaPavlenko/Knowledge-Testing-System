using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTestingSystem.DAL.Repositories;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

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
