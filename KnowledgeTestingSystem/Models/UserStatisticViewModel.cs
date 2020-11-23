using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeTestingSystem.Models
{
    public class UserStatisticViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Count Correct Answer")]
        public int CountCorrectAnswer { get; set; }
        [Required]
        [Display(Name = "Start time")]
        public DateTime DateTimeStart { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public DateTime DateTimeEnd { get; set; }
        [Required]
        [Display(Name = "Percent correct answers")]
        public double PercentCorrectAnswer { get; set; }
        [Display(Name = "Test name")]
        public string Test { get; set; }
        [Display(Name = "User email")]
        public string User { get; set; }
        public int TestId { get; set; }
        public string UserEntityId { get; set; }
    }
}