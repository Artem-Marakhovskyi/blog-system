using System.Collections;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Content { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
