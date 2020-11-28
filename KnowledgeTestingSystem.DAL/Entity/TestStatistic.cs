using System;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class TestStatistic : BaseEntity
    {
        public int Count { get; set; }
        public TimeSpan AverageTime { get; set; }
        public DateTime TimeLastUpdateStatistic { get; set; }
        public int AveragePercentCorrectAnswer { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}