using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using DataAccessLayer.IdentityRepository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice.Startup))]
namespace Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddRolesIfNotExists();
        }

        private void AddRolesIfNotExists()
        {
            new IdentityRepository().AddRolesToIdentity();
        }
    }
}
