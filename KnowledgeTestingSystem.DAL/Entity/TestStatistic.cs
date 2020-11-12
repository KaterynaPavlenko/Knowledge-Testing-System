using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestingSystem.DAL.Entity
{
    class TestStatistic:BaseEntity
    {
        public int Count { get; set; }
        public int AverageTime { get; set; }

    }
}
