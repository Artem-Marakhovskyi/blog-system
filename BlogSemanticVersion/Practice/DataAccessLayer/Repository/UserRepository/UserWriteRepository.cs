using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer.Repository.UserRepository
{
    public class UserWriteRepository
    {
        private BlogEntities _context;

        public UserWriteRepository()
        {
            _context = new BlogEntities();
        }

        public void ChangeToRole(string email, string role)
        {
            var roleToBeSet = _context.Roles.First(e => e.Name == role);

            var user = _context.Set<ApplicationUser>().First(e => e.Email == email);

            user.Roles.Clear();
            user.Roles.Add(new IdentityUserRole(){RoleId = roleToBeSet.Id, UserId = user.Id});

            _context.SaveChanges();
        }
    }
}
