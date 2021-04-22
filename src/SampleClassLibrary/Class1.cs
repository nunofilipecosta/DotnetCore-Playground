using System;

namespace SampleClassLibrary
{

    // 0b as a prefix for binary
    [Flags]
    public enum StaffRole
    {
        Instructor = 0b1,
        Researcher = 0b10,
        DepartmentChair = 0b100,
        Cleaner = 0b1000,
        DroppingThings = 16,
        Provost = 0b10000000,
        RaceCarDriver = 0b10000001,
        Singer = 0b_1000_0010
    }

    // separate long numbers
    public class Earnings
    {
        public int Mountly = 170_000_000;
        public int Yearly = 100000000;
    }

    // inline out parameter + string interpolation
    public class DoStuff
    {
        public void DoSomething()
        {
            int initializeInMethod;
            OutArgExample(out initializeInMethod);
            Console.WriteLine(string.Format("Count: {0}", initializeInMethod));
        }

        public void DoSomethingTwo()
        {
            OutArgExample(out int inlineDeclaration);
            Console.WriteLine($"Count : {inlineDeclaration}");
        }

        void OutArgExample(out int number)
        {
            number = 44;
            
        }


    }
}
