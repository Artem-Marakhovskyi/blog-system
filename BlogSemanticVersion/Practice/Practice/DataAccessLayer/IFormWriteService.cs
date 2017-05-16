using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    interface IFormWriteService
    {
        void AddForm(Form form);
    }
}
