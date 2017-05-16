using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.TagRepositoy.Interface
{
    public interface ITagWriteRepository
    {
        void AddTag(Tag tag);
    }
}
