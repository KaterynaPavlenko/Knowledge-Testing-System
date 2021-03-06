﻿namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int? QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; }
    }
}