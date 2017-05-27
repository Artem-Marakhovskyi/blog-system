using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository.UserRepository
{
    public class UserReadRepository
    {
        private BlogEntities _context;

        public UserReadRepository()
        {
            _context = new BlogEntities();
        }

        public IList<ApplicationUser> Get()
        {
            return _context.Users.ToList();
        }
    }
}
