using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public class FeedbackWriteService       :IFeedbackWriteService
    {
        private ContextEntities _context;

        public FeedbackWriteService(ContextEntities context)
        {
            _context = context;
        }

        public void AddFeedback(Feedback fbck)
        {
            _context.Feedbacks.Add(fbck);
            _context.SaveChanges();
        }
    }
}