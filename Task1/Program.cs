using System;
namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
          
            while (true)
            {

                try
                {
                    string input =  Console.ReadLine();
                    Console.WriteLine(ReturnFirstCharacter(input));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }

        public static char ReturnFirstCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty string");
            }
            return input[0];
        }
    }
}