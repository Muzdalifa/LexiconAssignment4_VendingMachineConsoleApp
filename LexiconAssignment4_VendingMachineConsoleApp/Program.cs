using LexiconAssignment4_VendingMachineConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LexiconAssignment4_VendingMachineConsoleApp
{
    class Program
    {
        public static VendingMachine vendingMashine = new VendingMachine();
        static void Main(string[] args)
        {
            StartVendingMachine();
        }

        public static void StartVendingMachine()
        {
            ConsoleKey userInput;

            int productId;

            do
            {
                Console.Clear();
                Console.WriteLine("----------Welcom to Muzda's Vending mashine----------");

                //step 1: Show all product in the vending machine
                vendingMashine.ShowAll();

                if (vendingMashine.MoneyPool < 5)
                {
                    //step 2: Insert money from money denomination
                    vendingMashine.InsertMoney(InsertMoneyToVM());
                }                

                //3 : Select product(s)
                productId = GetNumber("Select a product to purchase.\nEnter its Id : ");

                //4 : Purchase a product
                Product purchasedProduct = vendingMashine.Purchase(productId);

                //5 : Give product Info 
                Console.WriteLine($"Product information :\n{purchasedProduct.Examine()}");

                //6 : Use
                Console.WriteLine($"Product Use :\n{purchasedProduct.Use()}");                

                Console.WriteLine("Do you want to buy again? Y/N");
                userInput = Console.ReadKey(true).Key;

                if(userInput != ConsoleKey.N)
                {
                    Thread.Sleep(800);
                    //PressAnyKeyToContinue();
                }                

            } while (userInput != ConsoleKey.N);

            //step 7: Return change            
            Dictionary<int, int> change = vendingMashine.EndTransaction(productId);
            DisplayChange(change);

        }

        public static int InsertMoneyToVM()
        {
            Console.Write($"You can enter money among the following money denominations : ");
            //output MoneyDenominations array 
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

            return GetNumber("Enter money : ");
        }

        //Function to get id from the user
        public static int GetNumber(string words)
        {
            //set flag to restrict the user to enter only numbers
            bool flag = false;
            int id;
            do
            {
                Console.Write(words);
                flag = Int32.TryParse(Console.ReadLine(), out id);
                if (!flag)
                {
                    Console.WriteLine("The number you enterd is not valid! Please enter valid number.");
                }
            } while (!flag);

            return id;

        }

        public static void DisplayChange(Dictionary<int, int> change)
        {
            int sum = 0;
            foreach (KeyValuePair<int, int> pair in change)
            {
                sum = sum + pair.Value;
            }
            //check if there is a change to return
            if (sum != 0)
            {
                Console.WriteLine("Please take your change : ");

                foreach (KeyValuePair<int, int> pair in change)
                {
                    Console.WriteLine($"{pair.Key}x{pair.Value}");
                }
            }
            else
            {
                Console.WriteLine("Thank you for buying from us. Welcome again!");
            }
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to buy again!");
            Console.ReadKey(true);
        }
    }
}
