using System;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class StatisticDTO
    {
        public int Id { get; set; }
        public int CountCorrectAnswer { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
    }
}