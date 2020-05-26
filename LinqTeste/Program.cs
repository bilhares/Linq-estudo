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
            //busca os pares da fonte de dados e multiplica cada par por 10
            var result = numbers.Where(x => x % 2 == 0).Select(x => x * 10);

            foreach (int x in result)
            {
                Console.WriteLine(x);
            }

        }
    }
}
