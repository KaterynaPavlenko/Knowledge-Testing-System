using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingSystem.Models
{
    public class UserStatisticViewModel
    {
        public int Id { get; set; }
        public int CountCorrectAnswer { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int Mark { get; set; }
        public int TestId { get; set; }
        public string UserEntityId { get; set; }
    }
}