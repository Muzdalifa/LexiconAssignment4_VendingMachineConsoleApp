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
            Product selectedProduct = Products[id];
            
            //check if the moneypool is enough to buy product
            if(selectedProduct.Price > moneyPool)
            {
                throw new ArgumentException("The price of the product is high");
            }
            else
            {
                //remaining moneypol
                moneyPool = moneyPool - selectedProduct.Price;
            }

            return selectedProduct;
        }

        public Product[] ShowAll()
        {
            throw new NotImplementedException();
        }
    }
}
