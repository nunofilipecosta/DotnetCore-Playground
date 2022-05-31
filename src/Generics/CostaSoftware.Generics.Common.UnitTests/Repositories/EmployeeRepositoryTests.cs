using CostaSoftware.Generics.Common.Entities;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CostaSoftware.Generics.Common.UnitTests.Repositories;

public class EmployeeRepositoryTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public EmployeeRepositoryTests(ITestOutputHelper testOutputHelper)
    {
        this._testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void One()
    {
        var employeeRepository = new GenericRepository<Employee>();
        var knownGuid = Guid.NewGuid();
        employeeRepository.Add(new Employee { Id = knownGuid, FirstName = "John" });
        employeeRepository.Add(new Employee { FirstName = "Jane" });
        employeeRepository.Add(new Employee { FirstName = "Foo" });

        var itemToRemove = employeeRepository.GetById(knownGuid);

        Assert.NotNull(itemToRemove);

        var removed = employeeRepository.Remove(itemToRemove);

        Assert.True(removed);

    }
}
