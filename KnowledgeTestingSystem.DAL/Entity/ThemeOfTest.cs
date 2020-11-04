using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class ThemeOfTest : BaseEntity
    {
        private ThemeOfTest()
        {
            ThemesOfTests = new List<ThemeOfTest>();
        }

        public string Theme { get; set; }

        public virtual ICollection<ThemeOfTest> ThemesOfTests { get; set; }
    }
}