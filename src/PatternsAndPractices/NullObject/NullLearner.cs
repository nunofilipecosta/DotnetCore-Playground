namespace PatternsAndPractices.NullObject
{
    public class NullLearner : ILearner
    {
        public int Id => -1;

        public string UserName => "Just Browsing";

        public int CoursesCompleted => 0;
    }
}