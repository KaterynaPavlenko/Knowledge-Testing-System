using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class ThemeOfTest : BaseEntity
    {
        public ThemeOfTest()
        {
            Tests = new List<Test>();
        }

        public string Theme { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}