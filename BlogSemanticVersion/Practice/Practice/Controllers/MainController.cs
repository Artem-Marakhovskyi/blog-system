﻿using System;
using System.Web.Mvc;
using DataAccessLayer.Repository.ArticleRepository;
using DataAccessLayer.Repository.TagRepositoy;
using Practice.ViewModels.Main;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccessLayer.Repository.QuizRepository;
using DataAccessLayer.Entities;
using DataAccessLayer.IdentityRepository;
using DataAccessLayer.Repository.FeedbackRepository;
using DataAccessLayer.Repository.UserArticleLikesRepository;

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
        private readonly FeedbackReadRepository feedbackReadRepository;
        private readonly FeedbackWriteRepository feedbackWriteRepository;
        private MainViewModel model = new MainViewModel();
        private UserArticleLikesRepository userArticleLikeRepository;



        public MainController()
        {
            articleReadRepository = new ArticleReadRepository();
            articleWriteRepository = new ArticleWriteRepository();
            tagReadRepository = new TagReadRepository();
            tagWriteRepository = new TagWriteRepository();
            quizReadRepository = new QuizReadRepository();
            quizWriteRepository = new QuizWriteRepository();
            identityRepository = new IdentityRepository();
            feedbackReadRepository = new FeedbackReadRepository();
            feedbackWriteRepository = new FeedbackWriteRepository();
            userArticleLikeRepository = new UserArticleLikesRepository();

        }

        [HttpGet]
        public ActionResult ShowMainForm(string tag)
        {
            if (Session["Answer"] == null)
            {
                Session["Answer"] = true;
            }
            if (!String.IsNullOrWhiteSpace(tag))
            {
                model.SearchTag = tag;
            }

            model.Articles = articleReadRepository.GetArticles(tag) as List<Article>;
            model.Tags = tagReadRepository.GetTags();
            model.Quizes = quizReadRepository.GetQuizes();

            return View(model);
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var itemArticle = articleReadRepository.GetArticleById(id);
            return View(itemArticle);
        }

        [HttpPost]
        public ActionResult Info(Feedback feedback)
        {
            feedback.Login = HttpContext.User.Identity.Name;
            feedbackWriteRepository.AddFeedback(feedback);

            return RedirectToAction("Info", new { id = feedback.ArticleId });
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
        public ActionResult ShowMainForm(MainViewModel form, string authorName)
        {
            string path = string.Empty;
            if (Request.Files.Count > 0 && Request.Files[0].ContentType.Contains("image"))
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                     path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(path);
                }
            }

            var newArticle = new Article()
            {
                Content = form.Content,
                Data = DateTime.Now.ToShortDateString(),
                Title = form.Title,
                Tags = new List<Tag>(form.SetTags.Select(x=>new Tag()
                {
                    Content = x
                })),
                AuthorEmail = authorName,
                FileName = path
            };

            articleWriteRepository.AddArticle(newArticle);
            return RedirectToAction("ShowMainForm", "Main");
        }

        [HttpPost]
        public ActionResult Like(int articleId)
        {
            userArticleLikeRepository.Like(new UserArticleLike() { ArticleId = articleId, Username = User.Identity.Name });

            return RedirectToAction("Info", new { id = articleId });
        }
    }
}