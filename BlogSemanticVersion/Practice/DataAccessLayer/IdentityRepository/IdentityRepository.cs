using DataAccessLayer.Context;
using System.Linq;

namespace DataAccessLayer.IdentityRepository
{
    public class IdentityRepository
    {
        private BlogEntities _context;

        public IdentityRepository()
        {
            _context = new BlogEntities();
        }

        public void AddRolesToIdentity()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "1", Name = "Admin" });
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "2", Name = "User" });
            }
        }
    }
}
