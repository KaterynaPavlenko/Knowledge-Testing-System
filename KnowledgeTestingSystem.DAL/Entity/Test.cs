using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Test : BaseEntity
    {
        public Test()
        {
            Questions = new List<Question>();
            UserStatistics=new List<UserStatistic>();
        }
        public string Name { get; set; }
        public int ThemeOfTestId { get; set; }
        public int TimeMinutes { get; set; }
        public string CoverImage { get; set; }
        public virtual ThemeOfTest ThemeOfTest { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserStatistic> UserStatistics { get; set; }
    }
}