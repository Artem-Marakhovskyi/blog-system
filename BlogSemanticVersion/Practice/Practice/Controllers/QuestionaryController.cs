using DataAccessLayer.Entities;
using DataAccessLayer.Repository.FormRepository;
using Practice.ViewModels.Questionary;

using System.Web.Mvc;
namespace Practice.Controllers
{
    public class QuestionaryController : Controller
    {
        private readonly FormWriteRepository formWriteRepository;
        private readonly QuestionaryFormView questionaryFormView;

        public QuestionaryController()
        {
            formWriteRepository = new FormWriteRepository();
            questionaryFormView = new QuestionaryFormView();
        }

        [HttpGet]
        public ActionResult ShowQuestionaryForm()
        {
            return View(questionaryFormView);
        }

        [HttpPost]
        public ActionResult ShowQuestionaryForm(QuestionaryFormView questionary)
        {
            var newForm = new Form()
            {
                Name = questionary.Name,
                Age = questionary.Age,
                City = questionary.City,
                Email = questionary.Email,
                FavouriteBrowser = questionary.Browser,
                MarkOfForm = questionary.Mark,
                Phone = questionary.Phone,
                Preferable = questionary.GetPreferable
            };

            formWriteRepository.AddForm(newForm);
            return RedirectToAction("ShowResultForm", "Result");
        }
    }
}