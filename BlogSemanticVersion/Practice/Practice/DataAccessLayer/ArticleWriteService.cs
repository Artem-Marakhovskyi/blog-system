using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class ArticleWriteService        :IArticleWriteService
    {
        private ContextEntities _context;

        public ArticleWriteService(ContextEntities context)
        {
            _context = context;
        }

        public void WriteAtricle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
    }
}