using System;

namespace PatternsAndPractices.NullObject
{
    internal class LearnerService
    {
        private readonly LearnerRepo learnerRepo;
        public LearnerService()
        {
            this.learnerRepo = new LearnerRepo();
        }

        public ILearner GetCurrenLearner()
        {
            // get the leanerId from somewhere
            int learnerId = -1;

            var learner = this.learnerRepo.GetLearner(learnerId);

            /// if (learner == null) throw new NullReferenceException();
            if(learner == null)
            {
                return new NullLearner();
            }

            return learner;
        }
    }
}