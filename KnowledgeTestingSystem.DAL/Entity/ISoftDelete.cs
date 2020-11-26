using System;

namespace KnowledgeTestingSystem.DAL.Entity
{
    internal interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}