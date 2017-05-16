using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.TagRepositoy.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.TagRepositoy
{
    public class TagReadRepository:ITagReadRepository
    {
        private readonly BlogEntities context;

        public TagReadRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Get All tags
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetTags()
        {
            return context.Tags.ToList();
        }
    }
}
