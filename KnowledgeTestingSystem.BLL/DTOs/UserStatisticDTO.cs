using System;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class UserStatisticDTO
    {
        public int Id { get; set; }
        public int CountCorrectAnswer { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public double PercentCorrectAnswer { get; set; }
        public int TestId { get; set; }
        public string UserEntityId { get; set; }
    }
}