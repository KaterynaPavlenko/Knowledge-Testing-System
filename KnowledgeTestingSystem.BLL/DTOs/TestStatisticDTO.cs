using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTestingSystem.BLL.DTOs
{
    public class TestStatisticDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public TimeSpan AverageTime { get; set; }
        public DateTime TimeLastUpdateStatistic { get; set; }
        public int AveragePercentCorrectAnswer { get; set; }
        public int TestId { get; set; }
        public string Test { get; set; }
    }
}
