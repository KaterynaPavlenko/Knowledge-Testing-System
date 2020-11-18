using System.Collections.Generic;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int? QuestionsTypesId { get; set; }
        public int TestId { get; set; }
        public IEnumerable<AnswerDTO> Answer { get; set; }
    }
}