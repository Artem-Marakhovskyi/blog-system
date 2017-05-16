using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository.FormRepository.Interface
{
    public interface IFormReadRepository
    {
        ICollection<Form> GetForms();
    }
}
