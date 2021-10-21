namespace CostaSoftware.Tutorial.Collections
{
    public class ArrayTutorial
    {
        public void Create()
        {
            int[] numbers = null;

            Display("Array is create: " + (numbers == null).ToString());

            numbers = new int[3];
            Display("Array is null " + (numbers == null).ToString());

            Display("Array sizer " + numbers.Length);
        }

        private void Display(string line)
        {
            Console.WriteLine(line);
        }
    }
}