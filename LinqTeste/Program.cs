using LinqTeste.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTeste
{
    class Program
    {
        static void Print<T>(String message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //fonte de dados
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            //consulta
            //busca os pares da fonte de dados e multiplica cada par por 10
            numbers.Where(x => x % 2 == 0).Select(x => x * 10);


            //product search

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product(){Id = 1, Name = "Computer", Price = 1100.0, Category=c2},
                new Product(){Id = 2, Name = "Hammer", Price = 90.0, Category=c1},
                new Product(){Id = 3, Name = "TV", Price = 1700.0, Category=c3},
                new Product(){Id = 4, Name = "Notebook", Price = 1300.0, Category=c2},
                new Product(){Id = 5, Name = "Saw", Price = 80.0, Category=c1},
                new Product(){Id = 6, Name = "Tablet", Price = 700.0, Category=c2},
                new Product(){Id = 7, Name = "Camera", Price = 50.0, Category=c3},
                new Product(){Id = 8, Name = "Printer", Price = 500.0, Category=c3},
                new Product(){Id = 9, Name = "Macbook", Price = 7200.0, Category=c2},
                new Product(){Id = 10, Name = "Sound Bar", Price = 2300.0, Category=c3},
                new Product(){Id = 11, Name = "Level", Price = 50.0, Category=c1}
            };



            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("Tier 1 and price < 900:", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("Name of products from TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("Names started with C and anonymous object", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("Tier 1 order by price and name", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("Tier 1 order by price and name skip 2 and take 4 ", r5);

            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default: " + r6);

            //quando utilizado o "orDefault" em caso de nao encontrar o item retorna nulo ao inves de erro
            var r7 = products.Where(p => p.Price > 9000.0).FirstOrDefault();
            Console.WriteLine("First or default: " + r7);

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default: " + r8);

            var r9 = products.Max(p => p.Price);
            Console.WriteLine("Max price: " + r9);
            
            var r10 = products.Min(p => p.Price);
            Console.WriteLine("Min price: " + r10);

            //soma dos precos de uma categoria especifica
            var r11 = products.Where(p => p.Category.Id == 2).Sum(p => p.Price);
            Console.WriteLine("Sum prices:" + r11);

            //media dos precos de uma categoria especifica
            var r12 =  products.Where(p => p.Category.Id == 2).Average(p => p.Price);
            Console.WriteLine("Media dos precos:" + r12);

            var r13 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Media dos precos em caso de nulo: "+ r13);

            var r14 = products.Where(p => p.Category.Id == 2).Select(p => p.Price).Aggregate(0.0, (x,y) => x + y);
            Console.WriteLine("Aggregate manual para soma: "+r14);
            Console.WriteLine();
            var r15 = products.GroupBy(p => p.Category);

            foreach(IGrouping<Category, Product> group in r15)
            {
                Console.WriteLine("Category: "+group.Key.Name);
                foreach(Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }



        }
    }
}
