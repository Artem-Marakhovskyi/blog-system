using System.Collections.Generic;
using DataAccessLayer.Entities;
using System.Linq;
using DataAccessLayer.Repository.FormRepository.Interface;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.FormRepository
{
    public class FormReadRepository : IFormReadRepository
    {
        private readonly BlogEntities context;

        public FormReadRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// get all form form database
        /// </summary>
        /// <returns></returns>
        public ICollection<Form> GetForms()
        {
            return context.Forms.ToList();
        }
    }
}
