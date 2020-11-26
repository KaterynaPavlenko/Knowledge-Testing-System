using System;

namespace KnowledgeTestingSystem.DAL.Entity
{
    public class BaseEntity : IBaseEntity, ISoftDelete
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}