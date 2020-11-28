using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;

namespace KnowledgeTestingSystem.Controllers
{
    [Authorize(Roles = "Administrator, Manager")]
    public class AdminController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestStatisticService _testStatisticService;
        private readonly IUserStatisticService _userStatisticService;

        public AdminController(IUserStatisticService userStatisticService, ITestService testService,
            ITestStatisticService testStatisticService)
        {
            _userStatisticService = userStatisticService;
            _testStatisticService = testStatisticService;
            _testService = testService;
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserStatistic()
        {
            try
            {
                var userStatistic = _userStatisticService.GetAll();
                if (userStatistic == null) return HttpNotFound();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserStatisticDTO, UserStatisticViewModel>())
                    .CreateMapper();
                var userStatisticViewModel =
                    mapper.Map<IEnumerable<UserStatisticDTO>, IEnumerable<UserStatisticViewModel>>(userStatistic);
                return View(userStatisticViewModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult TestStatistic()
        {
            try
            {
                var testStatistic = _testStatisticService.GetAll();
                if (testStatistic == null) return HttpNotFound();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestStatisticDTO, TestStatisticViewModel>())
                    .CreateMapper();
                var testStatisticModel =
                    mapper.Map<IEnumerable<TestStatisticDTO>, IEnumerable<TestStatisticViewModel>>(testStatistic);

                return View(testStatisticModel);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("TestStatistic")]
        public ActionResult UpdateStatistic()
        {
            try
            {
                var tests = _testService.GetAll();
                if (tests == null) return HttpNotFound();
                foreach (var test in tests) _testStatisticService.Update(test.Id);
                return RedirectToAction("TestStatistic");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}