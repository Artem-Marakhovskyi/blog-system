using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.TagRepositoy.Interface
{
    public interface ITagReadRepository
    {
        List<Tag> GetTags();
    }
}
