using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    public class VendingMachine : IVending
    {
        //fields
        readonly int[] moneyDenominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };

        int moneyPool;

        public int MoneyPool { get { return moneyPool;} }

        public Product[] Products = new Product[] { new Chocolate(), new Water(), new Pringles() };

        //properties
        public int[] MoneyDenominations { get { return moneyDenominations; } }

        //methods:

        //step 1: show all product
        public void ShowAll()
        {
            foreach (Product product in Products)
            {
                Console.WriteLine(product.Examine());
            }
            Console.WriteLine();
        }

        //step 2: Insert money to the VM
        public void InsertMoney(double amount)
        {
            //Array.Find by default returns 0 if it doesn't found 
            if (Array.Find(moneyDenominations, money => money == amount) != 0)
            {

                moneyPool += Convert.ToInt32(amount);
            }
            else
            {
                throw new ArgumentException("The money you enterd is not among the denominations!");
            }
        }

        //step 3: purchase a product
        public Product Purchase(int id)
        {
            Product selectedProduct = Array.Find(Products, product => product.Id == id);

            if(selectedProduct == null)
            {
                throw new ArgumentException("Product is not found!");
            }

            //check if the moneypool is enough to buy product
            if (selectedProduct.Price > moneyPool)
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

        //step 4: returns money left in appropriate amount of change(Dictionary), given poductId.
        public Dictionary<int, int> EndTransaction(int id)
        {
            //Find selected product
            Product selectedProduct = Array.Find(Products, product => product.Id == id);

            //Calcculate change

            Dictionary<int, int> changeDict = new Dictionary<int, int>();

            for (int i = moneyDenominations.Length - 1; i >= 0; i--)
            {
                //Check if change returned is not zero
                int change = moneyPool / moneyDenominations[i];

                if (change != 0)
                {
                    changeDict.Add(moneyDenominations[i], change);
                }

                moneyPool = moneyPool % moneyDenominations[i];
            }

            return changeDict;
        }

    }
}
