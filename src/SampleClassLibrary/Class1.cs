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

    public class PersonStuff
    {
        public void DoStuff(Person person)
        {
            var student = person as Student;
            if (student != null)
            {
                Console.WriteLine("Person is a student");
            }

            if (person is Student student1)
            {
                Console.WriteLine("Person is a student");
            }
        }

        public void DoSomethingElse(Person person)
        {
            switch (person)
            {
                case Student honorStudent when honorStudent.GPA > 3.2m:
                    {
                        Console.WriteLine("Thans for being an honer student");
                    }
                    break;
                case Student regularStuden:
                    {
                        Console.WriteLine("Thanks for being a student");
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Person is not a student");
                    }
                    break;

            }
        }

        private (int count, string textMessage) GetCountAndMessage()
        {
            return (1, "This is a return message");
        }

        public void UseTuples()
        {
            (int count, string textMessage) result = GetCountAndMessage();

            (int sum, string message) = GetCountAndMessage();

            Console.WriteLine(result.count + result.textMessage);
            Console.WriteLine(sum + message);

        }


        public void TryChangeRef()
        {
            var count = 1;
            var result = ChangeRef(ref count);

            Console.WriteLine(count);
            Console.WriteLine(result);
        }

        private int ChangeRef(ref int  count)
        {
            count = 10;
            return count;
        }
    }
}
