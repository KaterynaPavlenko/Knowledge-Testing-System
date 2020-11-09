using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class QuestionType : BaseEntity
    {
        public QuestionType()
        {
            Questions = new List<Question>();
        }

        public string Type { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}