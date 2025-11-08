using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace debugging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            for (int age=1; age<=50; age++)
            {
                Console.Write(age);
                total += age;
                printIsOld(age);
            }
            Console.ReadLine();
        }

        static int printIsOld(int age)
        {
            if (age <= 12)
                Console.WriteLine("Year Old is a Child.");
            if (age >12 && age < 20)
                Console.WriteLine("Year Old is a Teenager.");
            if (age >= 20 && age<=30)
                Console.WriteLine("Year Old is a Young Adult.");
            if (age> 30)
                Console.WriteLine("Year Old is a Middle Aged.");
            return ++age;
        }
    }
}
