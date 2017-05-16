using DataAccessLayer.Repository.FormRepository;
using System.Linq;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class ResultController : Controller
    {
       private readonly FormReadRepository formReadRepository = new FormReadRepository();


        [HttpGet]
        public ActionResult ShowResultForm()
        {
            var formCollection = formReadRepository.GetForms();
            return View(formCollection.Last());
        }

    }
}