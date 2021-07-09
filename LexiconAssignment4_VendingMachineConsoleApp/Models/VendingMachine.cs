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

        public Product[] Products = new Product[] { new Chocolate(), new Water(), new Pringles() };

        //properties
        public int[] MoneyDenominations { get { return moneyDenominations; } }

        //methods:
        //returns money left in appropriate amount of change(Dictionary).
        public Dictionary<int, int> EndTransaction(int money, int id)
        {
            //Find selected product
            Product selectedProduct = Array.Find(Products, product => product.Id == id);

            //Calcculate change
            moneyPool = money - selectedProduct.Price;

            Dictionary<int, int> change = new Dictionary<int, int>();

            for (int i = moneyDenominations.Length - 1; i >= 0; i--)
            {
                change.Add(moneyDenominations[i], moneyPool / moneyDenominations[i]);

                moneyPool = moneyPool % moneyDenominations[i];
            }

            return change;
        }



        //step 2: Insert money to the VM
        public void InsertMoney(int amount)
        {
            if (Array.Find(moneyDenominations, money => money == amount) != 0)
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
            Product selectedProduct = Array.Find(Products, product => product.Id == id);

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

            Console.WriteLine(selectedProduct.Examine());
            Console.WriteLine(selectedProduct.Use());

            return selectedProduct;
        }

        //step 1: show all product
        public void ShowAll()
        {
            foreach (Product product in Products)
            {
                Console.WriteLine(product.Examine());
            }
        }

    }
}
