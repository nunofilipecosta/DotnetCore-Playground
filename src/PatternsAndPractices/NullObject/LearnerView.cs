using System;

namespace PatternsAndPractices.NullObject
{
    internal class LearnerView
    {
        private ILearner learner;

        public LearnerView(ILearner learner)
        {
            ///if (learner == null) throw new ArgumentNullException();
            ///if (learner.UserName == null) throw new ArgumentNullException();

            this.learner = learner;
        }

        public void RenderView()
        {
            Console.WriteLine(this.learner);
            Console.WriteLine(this.learner.UserName);
            Console.WriteLine(this.learner.CoursesCompleted);
        }
    }
}