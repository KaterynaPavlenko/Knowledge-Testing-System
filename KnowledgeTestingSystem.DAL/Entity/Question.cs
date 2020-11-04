using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Question : BaseEntity
    {
        private Question()
        {
            Answers = new List<Answer>();
        }

        public string Text { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}