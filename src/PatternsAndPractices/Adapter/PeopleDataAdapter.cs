using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatternsAndPractices.Adapter
{

    public abstract class PeopleDataAdapter
    {
        public abstract Task<List<Person>> GetPeople();

        public virtual Task<List<Person>> GetMorePeople()
        {
            throw new System.NotImplementedException();
        }
    }
}
