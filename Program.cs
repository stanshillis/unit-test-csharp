using System;

namespace cstest
{
    class Program
    {
        static void Main(string[] args)
        {
            SayHi(Console.WriteLine);
        }

        public static void SayHi(Action<string> write)
        {
            write("Hello World!");
        }
    }
}
