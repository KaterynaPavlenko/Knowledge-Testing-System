using System.Collections.Generic;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeMinutes { get; set; }
        public int ThemeOfTestId { get; set; }
        public string ThemeOfTest { get; set; }
        public string CoverImage { get; set; }
        public IEnumerable<QuestionDTO> Question { get; set; }
    }
}