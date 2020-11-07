using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Test : BaseEntity
    {
        public Test()
        {
            Questions = new List<Question>();
        }
        public string Name { get; set; }
        public int ThemeOfTestId { get; set; }

        public virtual ThemeOfTest ThemeOfTest { get; set; }
        
        public virtual ICollection<Question> Questions { get; set; }
    }
}