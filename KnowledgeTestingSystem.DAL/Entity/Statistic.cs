using System;
using System.Collections.Generic;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class Statistic : BaseEntity
    {
        public Statistic()
        {
            Tests = new List<Test>();
        }

        public int CountCorrectAnswer { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int Mark { get; set; }
        public string UserEntityId{ get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}