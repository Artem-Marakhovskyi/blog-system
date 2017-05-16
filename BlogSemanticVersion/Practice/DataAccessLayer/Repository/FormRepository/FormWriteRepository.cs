using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository.FormRepository.Interface;

namespace DataAccessLayer.Repository.FormRepository
{
    public class FormWriteRepository : IFormWriteRepository
    {
        private readonly BlogEntities context;

        public FormWriteRepository()
        {
            context = new BlogEntities();
        }

        /// <summary>
        /// Add new form to database
        /// </summary>
        /// <param name="form"></param>
        public void AddForm(Form form)
        {
            context.Forms.Add(form);
            context.SaveChanges();
        }
    }
}
