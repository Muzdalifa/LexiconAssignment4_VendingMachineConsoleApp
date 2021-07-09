using LexiconAssignment4_VendingMachineConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace LexiconAssignment4_VendingMachineConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vending mashine ");

            VendingMachine vendingMashine = new VendingMachine();

            //VendingMachine.CalculateChange();
            //Print 
            foreach (KeyValuePair<int,int> pair in vendingMashine.EndTransaction())
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
            Console.WriteLine(vendingMashine.EndTransaction());
        }
    }
}
