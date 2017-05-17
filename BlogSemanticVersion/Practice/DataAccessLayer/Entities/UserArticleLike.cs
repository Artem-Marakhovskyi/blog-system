using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserArticleLike
    {
        public int UserArticleLikeId { get; set; }

        public int ArticleId { get; set; }

        public string Username { get; set; }

        public bool Liked { get; set; }

        public Article Article { get; set; }
    }
}
