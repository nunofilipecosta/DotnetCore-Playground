using System;

namespace NullableReferenceTypePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = null;
            Console.WriteLine(text1);

            string? text2 = null;
            Console.WriteLine(text2);

            var legacyClass = new LegacyClass();

            Console.WriteLine($"int :: {legacyClass.NotNullZero}");
            Console.WriteLine($"string :: {legacyClass.NotNullString}");
            Console.WriteLine($"int :: {legacyClass.NullZero}");
            Console.WriteLine($"string :: {legacyClass.NullString}");

            legacyClass = null;
            Console.WriteLine($"reference type :: {legacyClass.NotNullZero}");

            Console.WriteLine("Hello World!");
        }
    }


    public class LegacyClass
    {
        public int NotNullZero { get; set; }

        public string NotNullString { get; set; }

        public int? NullZero { get; set; }

        public string? NullString { get; set; }
    }

}
