using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeTestingSystem.Models
{
    public class TestViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a test name")]
        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a minutes")]
        [Display(Name = "Minutes")]
        [Range(1, 120, ErrorMessage = "Invalid value. Valid values are from 1 to 120")]
        public int TimeMinutes { get; set; }

        [Display(Name = "Theme")]
        public string ThemeOfTest { get; set; }
        [Display(Name = "Cover Image")]
        public string CoverImage { get; set; }

        [Display(Name = "Star Time")] 
        public DateTime StarTime { get; set; }

        public int ThemeOfTestId { get; set; }
        public List<QuestionViewModel> Question { get; set; }
    }
}