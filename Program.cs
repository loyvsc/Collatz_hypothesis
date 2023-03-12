namespace Collatz_Hypothesis
{
    internal class Program
    {
        public static void Main()
        {
            Hypothesis.Collatz instanse = new Hypothesis.Collatz() { Number = 4 };
            instanse.Calculate();
            Console.WriteLine(instanse);
        }
    }
}