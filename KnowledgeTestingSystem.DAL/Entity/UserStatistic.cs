﻿using System;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class UserStatistic : BaseEntity
    {
        public int CountCorrectAnswer { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public TimeSpan UserTestTime { get; set; }
        public int PercentCorrectAnswer { get; set; }
        public string UserEntityId { get; set; }
        public int? TestId { get; set; }
        public virtual Test Test { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}