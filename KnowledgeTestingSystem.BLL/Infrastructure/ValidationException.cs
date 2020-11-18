using System;

namespace KnowledgeTestingSystem.BLL.Infrastructure
{
    internal class ValidationException : Exception
    {
        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }

        public string Property { get; set; }
    }
}