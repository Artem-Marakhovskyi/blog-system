using DataAccessLayer.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class BlogEntities : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public BlogEntities() : base(@"data source=(LocalDb)\MSSQLLocalDB;
                        initial catalog=IdentityBlogEntity;
                        integrated security=True;MultipleActiveResultSets=True;
                        App=EntityFramework")
        {

        }

        public static BlogEntities Create()
        {
            return new BlogEntities();
        }
    }

    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
