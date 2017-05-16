using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;

namespace Practice.DataAccessLayer
{
    public interface IFeedbackWriteService
    {
        void AddFeedback(Feedback fbck);
    }
}