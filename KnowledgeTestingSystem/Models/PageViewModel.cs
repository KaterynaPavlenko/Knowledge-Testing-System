using System;
using System.Collections.Generic;

namespace KnowledgeTestingSystem.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / PageSize);
    }

    public class IndexPageViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}