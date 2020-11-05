using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4307_0719
{
    class BusLines
    {
        private List<BusLineRoute> lines = new List<BusLineRoute>();

        public void AddOrRemove(string NumberOfLine, int choice)
        {

            if (choice == 0)
            {
                if (lines.Exists(line => line.BusLine == NumberOfLine))
                {
                    lines.Remove(lines.Find(line => line.BusLine == NumberOfLine));
                }
                else
                {
                    Console.WriteLine("The Line is not exist");
                }

            }
            else if (choice == 1)
            {
                List<BusLineRoute> lines1 = lines.FindAll(line => line.BusLine == NumberOfLine);
                if (lines1.Count() > 1)
                {
                    Console.WriteLine("There are identical lines");
                }
                else
                {
                    Console.WriteLine("Enter an area");
                    string area=Console.ReadLine();
                    if (lines1.Count() == 1)
                    {
                        if(area!=)




              }
                }
            }
        }
    }
