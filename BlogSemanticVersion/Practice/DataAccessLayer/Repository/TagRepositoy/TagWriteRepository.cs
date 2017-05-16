using DataAccessLayer.Repository.TagRepositoy.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.TagRepositoy
{
    public class TagWriteRepository : ITagWriteRepository
    {
        private readonly BlogEntities context;

        public TagWriteRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Add new Tag
        /// </summary>
        /// <param name="tag"></param>
        public void AddTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }
    }
}
