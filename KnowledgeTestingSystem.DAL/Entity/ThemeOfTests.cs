namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}