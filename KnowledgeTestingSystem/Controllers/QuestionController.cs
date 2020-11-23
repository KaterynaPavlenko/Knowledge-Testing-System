using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;

namespace KnowledgeTestingSystem.Controllers
{
    public class QuestionController : Controller
    {
        public readonly IQuestionService _questionService;
        public readonly IAnswerService _answerService;

        public QuestionController(IQuestionService questionService,IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateQuestion(int? testId)
        {
            if (testId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var question = new QuestionViewModel
            {
                TestId = testId.Value
            };
            return View(question);
        }
        [HttpPost]
        public ActionResult CreateQuestion(QuestionViewModel questionViewModel)
        {
            if (questionViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var answers = questionViewModel.Answer;
            questionViewModel.Answer = null;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, QuestionDTO>()).CreateMapper();
            var question = mapper.Map<QuestionViewModel, QuestionDTO>(questionViewModel);
            _questionService.Create(question);
            var newQuestion = _questionService.GetAll().FirstOrDefault(x => (x.Text == questionViewModel.Text && x.TestId == questionViewModel.TestId));
            if (newQuestion == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, AnswerDTO>()).CreateMapper();
            foreach (var answer in answers)
            {
                var answerDto = mapper.Map<AnswerViewModel, AnswerDTO>(answer);
                answerDto.QuestionId = newQuestion.Id;
                _answerService.Create(answerDto);
            }
            return RedirectToAction("CreateQuestion", "Question",new {id=newQuestion.TestId});
        }
    }
}