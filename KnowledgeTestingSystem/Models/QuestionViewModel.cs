using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowledgeTestingSystem.BLL.DTOs;

namespace KnowledgeTestingSystem.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int? QuestionsTypesId { get; set; }
        public int TestId { get; set; }
        public List<AnswerViewModel> Answer { get; set; }
    }
}