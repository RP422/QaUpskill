using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace qc_cohort_demo_MichaelLang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------");
            Console.WriteLine("Ex 1");
            Console.WriteLine("----------");
            Exercise_1();
            Console.WriteLine();

            Console.WriteLine("----------");
            Console.WriteLine("Ex 2");
            Console.WriteLine("----------");
            Exercise_2();
            Console.WriteLine();

            Console.WriteLine("----------");
            Console.WriteLine("Ex 3");
            Console.WriteLine("----------");
            Exercise_3();
            Console.WriteLine();
        }

        public static void Exercise_1()
        {
            string output = "Sorry, I'm a dev!";
            Console.WriteLine(output);
        }

        public static void Exercise_2()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int x in numbers)
            {
                if (x % 2 == 1)
                {
                    Console.WriteLine(x);
                }
            }
        }

        public static void Exercise_3()
        {
            string path = "files\\userData.json";
            List<Person> people = new List<Person>();

            string json = File.ReadAllText(path);
            people = JsonSerializer.Deserialize<List<Person>>(json);

            var filteredList = people.AsQueryable()
                                     .Where(x => x.email.Contains("aol.com"))
                                     .OrderBy(x => x.firstName)
                                     .ToList();

            for(int x = 0; x < filteredList.Count; x++)
            {
                Console.WriteLine("Person #" + (x + 1));
                Console.WriteLine("First Name: " + filteredList[x].firstName);
                Console.WriteLine("Last Name: " + filteredList[x].lastName);
                Console.WriteLine();
            }
        }
    }
}
