using System.Collections;
using System.Collections.Generic;
using System.Net;
using DataAccessLayer.Context;

namespace DataAccessLayer.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Data { get; set; }

        public string AuthorEmail { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        public ICollection<UserArticleLike> UserArticleLikes { get; set; } = new List<UserArticleLike>();

        public ApplicationUser Author { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}

