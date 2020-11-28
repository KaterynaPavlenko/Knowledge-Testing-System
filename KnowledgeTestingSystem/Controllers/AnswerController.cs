//using System.Net;
//using System.Web.Mvc;
//using AutoMapper;
//using KnowledgeTestingSystem.BLL.DTOs;
//using KnowledgeTestingSystem.BLL.Interfaces;
//using KnowledgeTestingSystem.Models;

//namespace KnowledgeTestingSystem.Controllers
//{
//    [Authorize(Roles = "Administrator")]
//    public class AnswerController : Controller
//    {
//        public readonly IAnswerService _answerService;
//        public readonly IQuestionService _questionService;

//        public AnswerController(IAnswerService answerService, IQuestionService questionService)
//        {
//            _answerService = answerService;
//            _questionService = questionService;
//        }

//        // GET: Answer
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        public ActionResult CreateAnswer(int? id)
//        {
//            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var answer = new AnswerViewModel
//            {
//                QuestionId = id.Value
//            };
//            return View(answer);
//        }

//        [HttpPost]
//        public ActionResult CreateAnswer(AnswerViewModel answerViewModel)
//        {
//            if (answerViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, AnswerDTO>()).CreateMapper();
//            var answer = mapper.Map<AnswerViewModel, AnswerDTO>(answerViewModel);
//            _answerService.Create(answer);
//            var question = _questionService.GetById(answer.QuestionId.Value);
//            return RedirectToAction("CreateQuestion", "Question", new {id = question.Id});
//        }
//    }
//}

