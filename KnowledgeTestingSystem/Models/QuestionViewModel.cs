using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KnowledgeTestingSystem.Models
{
    public class QuestionViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a question text")]
        [Display(Name = "Question")]
        public string Text { get; set; }

        [Display(Name = "Image")] public string Image { get; set; }

        [HiddenInput(DisplayValue = false)] public int? QuestionsTypesId { get; set; }

        [HiddenInput(DisplayValue = false)] public int TestId { get; set; }

        public List<AnswerViewModel> Answer { get; set; }
    }
}