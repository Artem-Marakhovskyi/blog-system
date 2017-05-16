using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class FeedbackReadService :IFeedbackReadService
    {
        private ContextEntities _context;

        public FeedbackReadService(ContextEntities context)
        {
            _context = context;
        }

        public List<Feedback> ReadFeadBack()
        {
            return _context.Feedbacks.ToList();
        }
    }
}