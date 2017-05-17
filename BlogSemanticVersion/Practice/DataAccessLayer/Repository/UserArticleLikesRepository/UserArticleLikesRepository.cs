using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.UserArticleLikesRepository
{
    public class UserArticleLikesRepository
    {
        private readonly BlogEntities context;

        public UserArticleLikesRepository()
        {
            context = new BlogEntities();
        }

        public bool Like(UserArticleLike userArticleLike)
        {
            if (context.UserArticleLikes.Count(
                    e => e.ArticleId == userArticleLike.ArticleId && e.Username == userArticleLike.Username) == 0)
            {
                context.UserArticleLikes.Add(userArticleLike);
                context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
