using System.Collections.Generic;
using System.Linq;

namespace PatternsAndPractices.NullObject
{
    public class LearnerRepo
    {
        readonly IList<Learner> learners = new List<Learner>();

        internal LearnerRepo()
        {
            learners.Add(new Learner(1, "David", 93));
            learners.Add(new Learner(2, "Julie", 72));
            learners.Add(new Learner(3,"Scott", 92));
        }

        internal ILearner GetLearner(int id)
        {
            bool learnerExists = this.learners.Any(l => l.Id == id);

            if(learnerExists)
            {
                return this.learners.FirstOrDefault(l => l.Id == id);
            }

            return null;
        }
    }
}