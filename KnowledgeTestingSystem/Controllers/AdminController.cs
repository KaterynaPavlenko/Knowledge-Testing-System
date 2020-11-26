using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;

namespace KnowledgeTestingSystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private ITestService _testService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ITestStatisticService _testStatisticService;

        public AdminController(IUserStatisticService userStatisticService,ITestService testService,ITestStatisticService testStatisticService)
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
            var userStatistic = _userStatisticService.GetAll().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserStatisticDTO, UserStatisticViewModel>())
                .CreateMapper();
            var userStatisticViewModel =
                mapper.Map<IEnumerable<UserStatisticDTO>, IEnumerable<UserStatisticViewModel>>(userStatistic);

            return View(userStatisticViewModel);
        }
        [HttpGet]
        public ActionResult TestStatistic()
        {
            var testStatistic = _testStatisticService.GetAll().ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestStatisticDTO, TestStatisticViewModel>())
                .CreateMapper();
            var testStatisticModel =
                mapper.Map<IEnumerable<TestStatisticDTO>, IEnumerable<TestStatisticViewModel>>(testStatistic);

            return View(testStatisticModel);
        }
        [HttpPost]
        [ActionName("TestStatistic")]
        public ActionResult UpdateStatistic()
        {
            var tests = _testService.GetAll().ToList();
            foreach (var test in tests)
            {
                _testStatisticService.Update(test.Id);
            }
            var testStatistic = _testStatisticService.GetAll().ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestStatisticDTO, TestStatisticViewModel>())
                .CreateMapper();
            var testStatisticModel =
                mapper.Map<IEnumerable<TestStatisticDTO>, IEnumerable<TestStatisticViewModel>>(testStatistic);

            return View(testStatisticModel);
        }
    }
}