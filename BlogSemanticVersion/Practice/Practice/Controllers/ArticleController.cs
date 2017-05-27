using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.ArticleRepository;
using DataAccessLayer.Repository.TagRepositoy;

namespace Practice.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleReadRepository _articleReadRepository;

        private ArticleWriteRepository _articleWriteRepository;

        private TagReadRepository _tagReadRepository;

        public ArticleController()
        {
            _articleReadRepository = new ArticleReadRepository();
            _articleWriteRepository = new ArticleWriteRepository();
            _tagReadRepository = new TagReadRepository();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = _articleReadRepository.GetArticleById(id);

            var tagsExist = _tagReadRepository.GetTags();
            
            foreach (var tag in article.Tags)
            {
                if (tagsExist.Any(e => e.Content == tag.Content))
                {
                    tagsExist.Remove(tagsExist.First(e => e.Content == tag.Content));
                }
            }
            
            ViewData["tags"] = tagsExist;

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article, string tags)
        {
            _articleWriteRepository.EditArticle(article, tags.Split(',').Where(e=>e.Length > 1).ToArray());
            return RedirectToAction("ShowMainForm", "Main");
        }
    }
}