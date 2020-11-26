using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
   public class TestStatisticRepository : Repository<TestStatistic>, ITestStatisticRepository
    {
        /// <summary>
        ///     Initializes a new instance of the TestStatisticRepository
        /// </summary>
        /// <param name="testingSystemDbContext">The context</param>
        public TestStatisticRepository(TestingSystemDbContext testingSystemDbContext) : base(testingSystemDbContext)
        {
        }
    }
}
