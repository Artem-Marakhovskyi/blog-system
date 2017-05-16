using DataAccessLayer.Entities;
using DataAccessLayer.Repository.FeedbackRepository;
using Practice.ViewModels.Living;
using System;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class LivingController : Controller
    {
        private readonly FeedbackReadRepository feedbackReadRepository;
        private readonly FeedbackWriteRepository feedbackWriteRepository;
        private LivingFormViewModel livingFormViewModel;

        public LivingController()
        {
            feedbackReadRepository = new FeedbackReadRepository();
            feedbackWriteRepository = new FeedbackWriteRepository();
            livingFormViewModel = new LivingFormViewModel();
        }

        [HttpGet]
        public ActionResult ShowLivingForm()
        {

            livingFormViewModel.Feedbacks = feedbackReadRepository.GetFeedbacks();
            return View(livingFormViewModel);
        }

        [HttpPost]
        public ActionResult ShowLivingForm(LivingFormViewModel data)
        {
            var newFeedback = new Feedback()
            {
                Comment = data.Feedback,
                Login = data.Name,
                Data = DateTime.Now.ToShortDateString()
            };

            feedbackWriteRepository.AddFeedback(newFeedback);
            return RedirectToAction("ShowLivingForm", "Living");
        }
    }
}