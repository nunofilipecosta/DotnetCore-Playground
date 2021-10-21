using System.Collections.Generic;

namespace PatternsAndPractices.Adapter.ThirdPartyApi
{
    public class PersonDTOApiResult
    {
        public int Count { get; set; }
        public List<PersonDTO> Results { get;  }
    }

}
