using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CostaSoftware.Generics.Common.UnitTests;
public class StackTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public StackTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void StackDoubles()
    {
        var stack = new Stack<double>();
        stack.Push(1.2);
        stack.Push(2.8);
        stack.Push(3.0);

        double sum = 0.0;
        while (stack.Count > 0)
        {
            double item = stack.Pop();
            _testOutputHelper.WriteLine($"Item : {item}");
            sum += item;
        }

        _testOutputHelper.WriteLine($"Sum : {sum}");
    }

    [Fact]
    public void StackStrings()
    {
        var stack = new Stack<string>();
        stack.Push("Starter");
        stack.Push("Course");
        stack.Push("Desert");

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            _testOutputHelper.WriteLine($"Item : {item}");;
        }
    }
}