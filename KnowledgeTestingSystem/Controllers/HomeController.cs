using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using KnowledgeTestingSystem.BLL.DTOs;
using KnowledgeTestingSystem.BLL.Interfaces;
using KnowledgeTestingSystem.Models;
using PagedList;

namespace KnowledgeTestingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        private readonly IThemeOfTestService _themeOfTestService;

        public HomeController(ITestService testService, IThemeOfTestService themeOfTestService)
        {
            _testService = testService;
            _themeOfTestService = themeOfTestService;
        }

        [HttpGet]
        public ActionResult Index(string searchString, string currentFilter, int page=1)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            var testsList = _testService.GetAll().ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestDTO, TestViewModel>()).CreateMapper();
            var tests = mapper.Map<IEnumerable<TestDTO>, IEnumerable<TestViewModel>>(testsList);
            if (!string.IsNullOrEmpty(searchString))
                tests = tests.Where(s =>
                    s.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.ThemeOfTest.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            //Contains(searchString)||s.Name.ToLower().Contains(searchString)||s.Name.ToUpper().Contains(searchString)
            //  || s.ThemeOfTest.Contains(searchString)|| s.ThemeOfTest.ToLower().Contains(searchString) || s.ThemeOfTest.ToUpper().Contains(searchString));
            var pageSize = 3;
            IEnumerable<TestViewModel> testInPages = tests.Skip((page - 1) * pageSize).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel{ PageNumber = page, PageSize = pageSize, TotalItems = tests.Count()};
            IndexPageViewModel ipvm = new IndexPageViewModel { PageViewModel = pageViewModel, Tests = testInPages };
            return View(ipvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Testing system";

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}