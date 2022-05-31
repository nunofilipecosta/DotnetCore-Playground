using Xunit;
using Xunit.Abstractions;

namespace CostaSoftware.Generics.Common.UnitTests;
public class GenericSimpleStackTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public GenericSimpleStackTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void StackDoubles()
    {
        var stack = new GenericSimpleStack<double>();
        stack.Push(1.2);
        stack.Push(2.8);
        stack.Push(3.0);

        double sum = 0.0;
        while (stack.Count > 0)
        {
            double item = (double)stack.Pop();
            _testOutputHelper.WriteLine($"Item : {item}");
            sum += item;
        }

        _testOutputHelper.WriteLine($"Sum : {sum}");
    }

    [Fact]
    public void StackStrings()
    {
        var stack = new GenericSimpleStack<string>();
        stack.Push("Starter");
        stack.Push("Course");
        stack.Push("Desert");

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            _testOutputHelper.WriteLine($"Item : {item}");
        }
    }
}