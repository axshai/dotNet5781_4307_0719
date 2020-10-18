using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_4307_0719
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4307();
            Welcome0719();
        }

        private static void Welcome4307()
        {
            Console.WriteLine("Enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }

        private static void Welcome0719()
        { 
        }
    }
}
