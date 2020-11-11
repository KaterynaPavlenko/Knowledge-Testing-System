using System;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class StatisticDTO
    {
        public int Id { get; set; }
        public int CountCorrectAnswer { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int Mark { get; set; }
        public string UserEntityId { get; set; }

    }
}