using LexiconAssignment4_VendingMachineConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace LexiconAssignment4_VendingMachineConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcom to Muzda's Vending mashine----------");
            //Console.WriteLine("Choose a product :");

            VendingMachine vendingMashine = new VendingMachine();

            //step 1: Show all product in the vending machine
            vendingMashine.ShowAll();

            //step 2: Insert money from money denomination
            Console.Write($"You can enter money among the following money denominations : ");

            for (int i = 0; i < vendingMashine.MoneyDenominations.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"[ {vendingMashine.MoneyDenominations[i]} ,");
                }
                else if (i == vendingMashine.MoneyDenominations.Length - 1)
                {
                    Console.WriteLine($"{vendingMashine.MoneyDenominations[i]} ]");
                }
                else
                {
                    Console.Write($"{vendingMashine.MoneyDenominations[i]} ,");
                }
            }

            Console.Write("Enter money : ");
            int moneyToPay = Convert.ToInt32(Console.ReadLine());

            vendingMashine.InsertMoney(moneyToPay);

            //step 3: Select a product to purchase
            Console.WriteLine("Select a product to purchase.");
            Console.Write("Enter its Id : ");
            
            int productId = Convert.ToInt32(Console.ReadLine());
            vendingMashine.Purchase(productId);

            //step 4: Take a change
            Dictionary<int, int> change = vendingMashine.EndTransaction(moneyToPay, productId);
            int sum = 0;
            foreach (KeyValuePair<int, int> pair in change)
            {
                sum = sum + pair.Value;
            }
            //check if there is a change to return
            if(sum != 0)
            {
                Console.WriteLine("Please take your change : ");

                foreach (KeyValuePair<int, int> pair in change)
                {
                    if (pair.Value != 0)
                    {
                        Console.WriteLine($"{pair.Key}x{pair.Value}");
                    }

                }
            }
            else
            {
                Console.WriteLine("Thank you for buying from us. Welcome again!");
            }

        }
    }
    }
