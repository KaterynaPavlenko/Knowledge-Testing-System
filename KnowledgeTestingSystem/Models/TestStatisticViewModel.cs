using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeTestingSystem.Models
{
    public class TestStatisticViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Number of test passes")]
        public int Count { get; set; }
        [Required]
        [Display(Name = "Average percent correct answer")]
        public int AveragePercentCorrectAnswer { get; set; }
        [Required]
        [Display(Name = "Average time of test passes")]
        public TimeSpan AverageTime { get; set; }
        [Required]
        [Display(Name = "Last update time")]
        public DateTime TimeLastUpdateStatistic { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "TestId")]
        public int TestId { get; set; }
        [Display(Name = "Test name")]
        public string Test { get; set; }
    }
}