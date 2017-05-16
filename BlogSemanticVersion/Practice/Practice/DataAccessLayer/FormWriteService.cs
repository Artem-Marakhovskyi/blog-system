using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class FormWriteService :IFormWriteService
    {
        private ContextEntities _context;

        public FormWriteService(ContextEntities context)
        {
            _context = context;
        }

        public void AddForm(Form form)
        {
            _context.Forms.Add(form);
            _context.SaveChanges();

        }
    }
}