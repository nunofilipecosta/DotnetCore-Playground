using System.Linq;

namespace PatternsAndPractices.NullObject
{
    internal interface ILearner
    {
        int Id { get; }
        string UserName { get; }
        int CoursesCompleted { get; }
    }
}