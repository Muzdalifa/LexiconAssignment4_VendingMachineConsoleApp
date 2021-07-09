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

        //returns money left in appropriate amount of change(Dictionary).
        public Dictionary<int, int> EndTransaction()
        {
            moneyPool = 9000;
            Dictionary<int, int> change = new Dictionary<int, int>();

            for (int i = moneyDenominations.Length - 1; i >= 0; i--)
            {
                if (moneyPool < moneyDenominations[i])
                {
                    change.Add(moneyDenominations[i], 0);
                }
                else
                {
                    change.Add(moneyDenominations[i],moneyPool / moneyDenominations[i]);

                    moneyPool = moneyPool % moneyDenominations[i];
                }
            }

            return change;
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

        public static void CalculateChange()
        {
            int[] arrayCoins = new int[] { 1, 5, 10, 50, 100, 500, 1000 };

            Random r = new Random();
            int bill = r.Next(0, 2000);

            int change;

            Console.Write($"Money to pay : {bill}");

            Console.Write(("Please enter the amount you want to pay : "));
            int amountToPay = int.Parse(Console.ReadLine());

            if (amountToPay > bill)
            {
                change = amountToPay - bill;
                Console.WriteLine($"Calculated change : {change}");
                Console.WriteLine("Coins distribution : ");

                for (int i = arrayCoins.Length - 1; i >= 0; i--)
                {
                    if (change < arrayCoins[i])
                    {
                        Console.WriteLine($"{arrayCoins[i]} coins : {0}");
                    }
                    else
                    {
                        Console.WriteLine($"{arrayCoins[i]} coins : {change / arrayCoins[i]}");

                        change = change % arrayCoins[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Your bill is too high than what you want to pay!");
            }



        }

        //public int EndTransaction()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
