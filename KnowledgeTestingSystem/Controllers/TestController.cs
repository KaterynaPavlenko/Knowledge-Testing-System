using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;
using Microsoft.AspNet.Identity;

namespace KnowledgeTestingSystem.Controllers
{
    public class TestController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        private readonly ITestService _testService;
        private readonly IThemeOfTestService _themeOfTestService;
        private readonly IUserStatisticService _userStatisticService;

        public TestController(ITestService testService, IAnswerService answerService, IQuestionService questionService,
            IThemeOfTestService themeOfTestService, IUserStatisticService userStatisticService)
        {
            _testService = testService;
            _answerService = answerService;
            _questionService = questionService;
            _themeOfTestService = themeOfTestService;
            _userStatisticService = userStatisticService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult Tests()
        {
            try
            {
                var tests = _testService.GetAll();
                if (tests == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                var testsViewModel = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(tests);
                return View(testsViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        #region CRUD

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteTest(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var test = _testService.GetById(id.Value);
                if (test == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);
                return View(testViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("DeleteTest")]
        [Authorize(Roles = "Administrator")]
        public ActionResult ConfirmDelete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var test = _testService.GetById(id.Value);
                if (test == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                _testService.Delete(id.Value);
                return RedirectToAction("Tests");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult CreateTest(TestViewModel testViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var fileName = Path.GetFileNameWithoutExtension(testViewModel.ImageFile.FileName);
                var extension = Path.GetExtension(testViewModel.ImageFile.FileName);
                fileName += extension;
                testViewModel.CoverImage = "~/Content/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Image/"), fileName);
                try
                {
                    testViewModel.ImageFile.SaveAs(fileName);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    ModelState.AddModelError("Error adding image", dirEx.Message);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestViewModel, TestDTO>()).CreateMapper();
                var test = mapper.Map<TestViewModel, TestDTO>(testViewModel);
                _testService.Create(test);

                var newTest = _testService.GetAll().FirstOrDefault(x =>
                    x.Name == testViewModel.Name && x.ThemeOfTest == testViewModel.ThemeOfTest);
                if (newTest == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                return RedirectToAction("Tests");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            //return RedirectToAction("CreateQuestion", "Question", new {testId = newTest.Id});
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult UpdateTest(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var test = _testService.GetById(id.Value);
                if (test == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);
                return View(testViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager")]
        public ActionResult UpdateTest(TestViewModel testViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var fileName = Path.GetFileNameWithoutExtension(testViewModel.ImageFile.FileName);
                var extension = Path.GetExtension(testViewModel.ImageFile.FileName);
                fileName += extension;
                testViewModel.CoverImage = "~/Content/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Image/"), fileName);
                try
                {
                    testViewModel.ImageFile.SaveAs(fileName);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    ModelState.AddModelError("Error adding image", dirEx.Message);
                }

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestViewModel, TestDTO>()).CreateMapper();
                var test = mapper.Map<TestViewModel, TestDTO>(testViewModel);
                _testService.Update(test);
                return RedirectToAction("Tests");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region Testing

        // GET: Test
        [HttpGet]
        public ActionResult InformAboutTest(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var test = _testService.GetById(id.Value);
                if (test == null) return HttpNotFound();

                var themeOfTest = _themeOfTestService.GetById(test.ThemeOfTestId.Value);
                if (themeOfTest == null) return HttpNotFound();

                test.ThemeOfTest = themeOfTest.Theme;
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);

                return View(testViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Testing(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var test = _testService.GetById(id.Value);
                if (test == null)
                    return HttpNotFound();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
                var testViewModel = mapper.Map<TestDTO, TestViewModel>(test);
                var questions = _questionService.GetAll().Where(x => x.TestId == id).ToList();
                if (questions.Count == 0) return RedirectToAction("Index", "Home");
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
                var questionsViewModel =
                    mapper.Map<IEnumerable<QuestionDTO>, IEnumerable<QuestionViewModel>>(questions);
                var answers = _answerService.GetAll();
                if (answers == null)
                    return HttpNotFound();
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerViewModel>()).CreateMapper();
                var answerViewModel =
                    mapper.Map<IEnumerable<AnswerDTO>, IEnumerable<AnswerViewModel>>(answers).ToList();
                foreach (var question in questionsViewModel)
                    question.Answer = answerViewModel.Where(x => x.QuestionId == question.Id).ToList();
                testViewModel.Question = questionsViewModel.ToList();
                if (testViewModel.StarTime < DateTime.Now) testViewModel.StarTime = DateTime.Now;
                return View(testViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Testing(TestViewModel testViewModel)
        {
            if (testViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var countCorrectAnswer = CountCorrectAnswer(testViewModel);
                var statisticViewModel = new UserStatisticViewModel
                {
                    CountCorrectAnswer = countCorrectAnswer,
                    DateTimeEnd = DateTime.Now,
                    DateTimeStart = testViewModel.StarTime,
                    TestId = testViewModel.Id,
                    UserEntityId = User.Identity.GetUserId(),
                    PercentCorrectAnswer = PercentCorrectAnswer(testViewModel, countCorrectAnswer)
                };
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserStatisticViewModel, UserStatisticDTO>())
                    .CreateMapper();
                var statistic = mapper.Map<UserStatisticViewModel, UserStatisticDTO>(statisticViewModel);
                _userStatisticService.Create(statistic);
                return RedirectToAction("CompleteTest", statisticViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        private int CountCorrectAnswer(TestViewModel test)
        {
            var correctAnswer = 0;
            foreach (var question in test.Question)
                if (question.Answer != null)
                    foreach (var answer in question.Answer)
                        if (answer.IsSelected && answer.IsCorrect)
                            correctAnswer++;
            return correctAnswer;
        }

        private int PercentCorrectAnswer(TestViewModel test, int countCorrectAnswer)
        {
            double allCorrectAnswer = 0;
            foreach (var question in test.Question)
                if (question.Answer != null)
                    foreach (var answer in question.Answer)
                        if (answer.IsCorrect)
                            allCorrectAnswer++;
            return (int) (countCorrectAnswer * 100 / allCorrectAnswer);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult CompleteTest(UserStatisticViewModel userStatisticViewModel)
        {
            return View(userStatisticViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult NotCompleteTest()
        {
            return View();
        }

        #endregion
    }
}