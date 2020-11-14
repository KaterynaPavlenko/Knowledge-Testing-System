using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;

namespace KnowledgeTestingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        private readonly IThemeOfTestService _themeOfTestService;

        public HomeController(ITestService testService,IThemeOfTestService themeOfTestService)
        {
            _testService = testService;
            _themeOfTestService = themeOfTestService;
        }
        public ActionResult Index(string searchString)
        {

            var testsList = _testService.GetAll().ToList();
            var mapper =new MapperConfiguration(cfg=>cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            var tests = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testsList);
            if (!String.IsNullOrEmpty(searchString))
            {
                tests = tests.Where(s => s.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0||s.ThemeOfTest.IndexOf(searchString,StringComparison.OrdinalIgnoreCase)>=0);
                //Contains(searchString)||s.Name.ToLower().Contains(searchString)||s.Name.ToUpper().Contains(searchString)
                //  || s.ThemeOfTest.Contains(searchString)|| s.ThemeOfTest.ToLower().Contains(searchString) || s.ThemeOfTest.ToUpper().Contains(searchString));
            }
            return View(tests);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}