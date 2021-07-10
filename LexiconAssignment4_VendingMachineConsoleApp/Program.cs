﻿using LexiconAssignment4_VendingMachineConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace LexiconAssignment4_VendingMachineConsoleApp
{
    class Program
    {
        public static VendingMachine vendingMashine = new VendingMachine();
        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcom to Muzda's Vending mashine----------");            
            
            //step 1: Show all product in the vending machine
            vendingMashine.ShowAll();

            //step 2: Insert money from money denomination
            vendingMashine.InsertMoney(InsertMoneyToVM());

            //3 : Select product(s)
            int productId = SelectProduct();

            //4 : Purchase a product
            Product purchasedProduct = vendingMashine.Purchase(productId);

            //5 : Give product Info 
            Console.WriteLine($"Product information :\n{purchasedProduct.Examine()}");

            //6 : Use
            Console.WriteLine($"Product Use :\n{purchasedProduct.Use()}");

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

            Console.Write("Enter money : ");
            return  Convert.ToInt32(Console.ReadLine());
        }

        //select a product
        public static int SelectProduct()
        {
            Console.WriteLine("Select a product to purchase.");
            
            Console.Write("Enter its Id : ");

            int productId = Convert.ToInt32(Console.ReadLine());

            return productId;
        }

        //public static int ProductInfo()
        //{
        //    string userInput;
        //    Product product = vendingMashine.Purchase(productId);

        //    Console.WriteLine($"Product information :\n{product.Examine()}");
        //    Console.WriteLine();
        //    Console.WriteLine($"Product Use :\n{product.Use()}");



        //    Console.WriteLine("Do you want to buy again? Y/N");
        //    userInput = Console.ReadLine();
        //}

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
