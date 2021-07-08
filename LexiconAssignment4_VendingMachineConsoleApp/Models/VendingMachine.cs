using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    class VendingMachine : IVending
    {
        //fields
        readonly int[] moneyDenominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        
        int moneyPool;

        public Product[] Products = new Product[] { new Water(), new Pringles(), new Chocolate() };

        public int EndTransaction()
        {
            throw new NotImplementedException();
        }

        // step 1: Insert money to the VM
        public void InsertMoney(int amount)
        {
           if(Array.Find(moneyDenominations, money => money == amount) != 0)
            {
                moneyPool += amount;
            }
            else
            {
                Console.WriteLine("The money you enterd is not among the denominations!");
            }            
        }

        public Product Purchase(int id)
        {
            throw new NotImplementedException();
        }

        public Product[] ShowAll()
        {
            throw new NotImplementedException();
        }
    }
}
