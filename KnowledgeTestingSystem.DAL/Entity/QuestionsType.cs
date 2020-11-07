using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class QuestionsType : BaseEntity
    {
        public QuestionsType()
        {
            Questions = new List<Question>();
        }

        public string Type { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}