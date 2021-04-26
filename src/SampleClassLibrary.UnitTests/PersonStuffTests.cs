using System;

using Xunit;
using Xunit.Abstractions;

namespace SampleClassLibrary.UnitTests
{
    public class PersonStuffTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public PersonStuffTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("ctor");
        }

        [Fact]
        public void TestRef()
        {
            var personStuff = new PersonStuff();

            personStuff.TryChangeRef();

            Assert.True(true);
        }
    }
}
