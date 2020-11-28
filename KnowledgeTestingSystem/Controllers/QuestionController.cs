//using System.Web.Mvc;
//using KnowledgeTestingSystem.BLL.Interfaces;

//namespace KnowledgeTestingSystem.Controllers
//{
//    [Authorize(Roles = "Administrator")]
//    public class QuestionController : Controller
//    {
//        public readonly IAnswerService _answerService;
//        public readonly IQuestionService _questionService;

//        public QuestionController(IQuestionService questionService, IAnswerService answerService)
//        {
//            _questionService = questionService;
//            _answerService = answerService;
//        }

//        //[HttpGet]
//        //public ActionResult CreateQuestion(int? testId)
//        //{
//        //    if (testId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    var question = new QuestionViewModel
//        //    {
//        //        TestId = testId.Value
//        //    };
//        //    return View(question);
//        //}

//        //[HttpPost]
//        //public ActionResult CreateQuestion(QuestionViewModel questionViewModel)
//        //{
//        //    if (questionViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    var answers = questionViewModel.Answer;
//        //    questionViewModel.Answer = null;
//        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, QuestionDTO>()).CreateMapper();
//        //    var question = mapper.Map<QuestionViewModel, QuestionDTO>(questionViewModel);
//        //    _questionService.Create(question);
//        //    var newQuestion = _questionService.GetAll().FirstOrDefault(x =>
//        //        x.Text == questionViewModel.Text && x.TestId == questionViewModel.TestId);
//        //    if (newQuestion == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
//        //    mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, AnswerDTO>()).CreateMapper();
//        //    foreach (var answer in answers)
//        //    {
//        //        var answerDto = mapper.Map<AnswerViewModel, AnswerDTO>(answer);
//        //        answerDto.QuestionId = newQuestion.Id;
//        //        _answerService.Create(answerDto);
//        //    }
//        //    return RedirectToAction("CreateQuestion", "Question", new {id = newQuestion.TestId});
//        //}
//    }
//}

