using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestingSystem.BLL.Infrastructure
{
    class ValidationException:Exception
    {
        public string Property { get; set; }

        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
