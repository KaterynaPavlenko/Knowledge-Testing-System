using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Question : BaseEntity
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public string Text { get; set; }
        public string Image { get; set; }
        public int? QuestionsTypesId { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual QuestionType QuestionsTypes { get; set; }
        public virtual Test Test { get; set; }

    }
}