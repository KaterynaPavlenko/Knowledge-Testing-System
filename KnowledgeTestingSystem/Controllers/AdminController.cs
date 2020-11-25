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

        public AdminController(IUserStatisticService userStatisticService)
        {
            _userStatisticService = userStatisticService;
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
    }
}