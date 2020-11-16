using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;
using Ninject.Infrastructure.Language;

namespace KnowledgeTestingSystem.Controllers
{
    public class TestController : Controller
    {
        public readonly ITestService _testService;
        public readonly IAnswerService _answerService;
        public readonly IQuestionService _questionService;
        public readonly IThemeOfTestService _themeOfTestService;
        public readonly IUserStatisticService _userStatisticService;

        public TestController(ITestService testService, IAnswerService answerService, IQuestionService questionService,
            IThemeOfTestService themeOfTestService, IUserStatisticService userStatisticService)
        {
            _testService = testService;
            _answerService = answerService;
            _questionService = questionService;
            _themeOfTestService = themeOfTestService;
            _userStatisticService = userStatisticService;
        }

        // GET: Test
        public ActionResult InformAboutTest(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var test = _testService.GetById(Id.Value);
            if (test == null)
            {
                return HttpNotFound();
            }

            var themeOfTest = _themeOfTestService.GetById(test.ThemeOfTestId);
            if (themeOfTest == null)
            {
                return HttpNotFound();
            }

            test.ThemeOfTest = themeOfTest.Theme;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);

            return View(testViewModel);

        }

        [HttpGet]
        public ActionResult Testing(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var questions = _questionService.GetAll().Where(x => x.TestId == Id).ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            var questionsViewModel = mapper.Map<IEnumerable<QuestionDTO>, IEnumerable<QuestionViewModel>>(questions);
            var answers = _answerService.GetAll().ToList();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
            var answerViewModel = mapper.Map<IEnumerable<AnswerDTO>, IEnumerable<AnswerViewModel>>(answers).ToList();
            foreach (var question in questionsViewModel)
            {

                question.Answer = answerViewModel.Where(x => x.QuestionId == question.Id).ToList();
            }

            var test = _testService.GetById(Id.Value);
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);
            testViewModel.Question = questionsViewModel.ToList();
            if (testViewModel.StarTime < DateTime.Now)
            {
                testViewModel.StarTime = DateTime.Now;
            }
            return View(testViewModel);

        }
        [HttpPost]
        public ActionResult Testing(TestViewModel testViewModel)
        {
            var corect = CountCorrectAnswer(testViewModel);
            return RedirectToAction("CompleteTest");
        }
        private int CountCorrectAnswer(TestViewModel test)
        {
            int correctAnswer = 0;
            foreach (var question in test.Question)
            {
                if (question.Answer != null)
                {
                    foreach (var answer in question.Answer)
                    {
                        if (answer.IsSelected && answer.IsCorrect)
                            correctAnswer++;
                    }

                }
            }
            return correctAnswer;
        }
        public ActionResult CompleteTest(UserStatisticViewModel userStatisticViewModel)
        {
            return View();
        }
        public ActionResult NotCompleteTest(UserStatisticViewModel userStatisticViewModel)
        {
            return View();
        }
    }
}