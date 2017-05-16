using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class FormReadService    :IFormReadService
    {
        public List<Form> ReadForm()
        {
            ContextEntities _context = new ContextEntities();
            return _context.Forms.ToList();
        }
    }
}