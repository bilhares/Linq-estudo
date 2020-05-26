using System;
using System.Linq;

namespace LinqTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            //fonte de dados
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            //consulta
            System.Collections.Generic.List<int> list = numbers.Where(x => x % 2 == 0).ToList();

            foreach(int x in list)
            {
                Console.WriteLine(x);
            }

        }
    }
}
