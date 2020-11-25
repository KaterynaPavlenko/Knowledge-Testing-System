using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeTestingSystem.Models
{
    public class AnswerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Answer text")]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? QuestionId { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Is selected by user")]
        public bool IsSelected { get; set; }
        [Required(ErrorMessage = "Please enter an answer status")]
        [Display(Name = "Is correct")]
        public bool IsCorrect { get; set; }
    }
}