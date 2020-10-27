using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsAndPractices.NullObject
{
    public class Main
    {
        public void DoStuff()
        {
            LearnerService learnerService = new LearnerService();
            ILearner learner = learnerService.GetCurrenLearner();

            LearnerView view = new LearnerView(learner);
            view.RenderView();
        }
    }
}
