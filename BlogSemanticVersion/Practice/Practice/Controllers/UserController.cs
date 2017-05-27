using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Repository.UserRepository;
using Practice.Models;

namespace Practice.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private UserReadRepository _userReadRepository;
        private UserWriteRepository _userWriteRepository;

        public UserController()
        {
            _userWriteRepository = new UserWriteRepository();
            _userReadRepository = new UserReadRepository();
        }
        
        public ActionResult List()
        {
            var users = _userReadRepository.Get().Select(e=> new UserViewModel()
            {
                Email = e.Email,
                Role = e.Roles.First().RoleId == "1" ? "Admin" : "User"
            }).ToList();

            var admin = users.First(e => e.Email == User.Identity.Name);

            users.Remove(admin);

            return View(users);
        }

        public ActionResult ChangeToRole(string email, string role)
        {
            _userWriteRepository.ChangeToRole(email, role);

            return RedirectToAction("List");
        }
    }
}