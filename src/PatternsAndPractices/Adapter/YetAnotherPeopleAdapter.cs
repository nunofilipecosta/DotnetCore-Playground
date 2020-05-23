using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatternsAndPractices.Adapter
{
    public class YetAnotherPeopleAdapter : PeopleDataAdapter
    {
        public override Task<List<Person>> GetPeople()
        {
            throw new NotImplementedException();
        }

        public override Task<List<Person>> GetMorePeople()
        {
            this.GetPeople();
            // Do Something and then 
            return base.GetMorePeople();
        }
    }
}
