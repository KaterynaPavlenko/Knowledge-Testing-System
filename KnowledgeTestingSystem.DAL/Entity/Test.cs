namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }

        public virtual ThemeOfTest ThemeOfTest { get; set; }
    }
}