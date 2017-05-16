using System;
using System.Web.Mvc;
using DataAccessLayer.Repository.ArticleRepository;
using DataAccessLayer.Repository.TagRepositoy;
using Practice.ViewModels.Main;
using System.Collections.Generic;
using DataAccessLayer.Repository.QuizRepository;
using DataAccessLayer.Entities;
using DataAccessLayer.IdentityRepository;

namespace Practice.Controllers
{
    public class MainController : Controller
    {
        private readonly ArticleReadRepository articleReadRepository;
        private readonly ArticleWriteRepository articleWriteRepository;
        private readonly TagReadRepository tagReadRepository;
        private readonly QuizReadRepository quizReadRepository;
        private readonly QuizWriteRepository quizWriteRepository;
        private readonly TagWriteRepository tagWriteRepository;
        private readonly IdentityRepository identityRepository;

        private MainViewModel model = new MainViewModel();

        public MainController()
        {
            articleReadRepository = new ArticleReadRepository();
            articleWriteRepository = new ArticleWriteRepository();
            tagReadRepository = new TagReadRepository();
            tagWriteRepository = new TagWriteRepository();
            quizReadRepository = new QuizReadRepository();
            quizWriteRepository = new QuizWriteRepository();
            identityRepository = new IdentityRepository();
        }

        [HttpGet]
        public ActionResult ShowMainForm()
        {
            if (Session["Answer"] == null)
            {
                Session["Answer"] = true;
            }
            model.Articles = articleReadRepository.GetArticles() as List<Article>;
            model.Tags = tagReadRepository.GetTags();
            model.Quizes = quizReadRepository.GetQuizes();

            return View(model);
        }

        [HttpGet]
        public ActionResult Info()
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            var itemArticle = articleReadRepository.GetArticleById(id);
            return View(itemArticle);
        }

        [HttpPost]
        public ActionResult Info(Feedback feedback)
        {
            // MY CODE
            //return View(itemArticle);
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(string TagContent)
        {
            var tag = new Tag { Content = TagContent };
            tagWriteRepository.AddTag(tag);

            return RedirectToAction("ShowMainForm", "Main");
        }
        [HttpPost]
        public ActionResult RemoveArticle(int id)
        {
            articleWriteRepository.DeleteArticle(id);
            return RedirectToAction("ShowMainForm", "Main");
        }

        [HttpPost]
        public ActionResult GetAnswer(int browser)
        {
            var quiz = new Quiz { QuizId = browser };
            quizWriteRepository.UpdateQuiz(quiz);
            Session["Answer"] = false;
            return RedirectToAction("ShowMainForm", "Main");
        }

        [HttpPost]
        public ActionResult ShowMainForm(MainViewModel form)
        {
            var newArticle = new Article()
            {
                Content = form.Content,
                Data = DateTime.Now.ToShortDateString(),
                Title = form.Title,
                Tags = form.ReadyTag
            };

            articleWriteRepository.AddArticle(newArticle);
            return RedirectToAction("ShowMainForm", "Main");
        }
    }
}