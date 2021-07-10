using System;
using Xunit;
using LexiconAssignment4_VendingMachineConsoleApp.Models;
using Xunit.Abstractions;
using System.Linq;
using System.Collections.Generic;

namespace VendingMachineConsoleApp.Test
{
    public class VendingMachineTest
    {
        public readonly VendingMachine _vendingMashine = new VendingMachine();

        //private readonly ITestOutputHelper output;

        [Fact]
        public void moneyDenominationsContainsCorrectCoins()
        {
            //Arange
            int expectedLength = 8;
            int[] expetedMoneyDenomination = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
            //Act
            int[] result = _vendingMashine.MoneyDenominations;

            //Assert
            Assert.Equal(expectedLength, result.Length);
            Assert.NotNull(result);
            Assert.Equal(result, expetedMoneyDenomination);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void InsertMoneyWorkCorrectly(int moneyToPay)
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();      

            //Act
            vendingMashine.InsertMoney(moneyToPay);

            //Act
            Assert.Equal(moneyToPay, vendingMashine.MoneyPool);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(300)]
        [InlineData(2000)]
        [InlineData(200.0)]
        [InlineData(-200)]
        public void InsertMoneyThrowExceptionWithIncorrectMoneyDenomination(int moneyToPay)
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            int moneyPool = vendingMashine.MoneyPool;

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>( ()=> vendingMashine.InsertMoney(moneyToPay));

            //Assert
            Assert.Equal("The money you enterd is not among the denominations!", result.Message);
        }


        [Fact]
        public void PurchaseChocolateWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Chocolate expectedChocolate = new Chocolate();

            //Act
            Product result = vendingMashine.Purchase(1);

            //Assert
            Assert.Equal(expectedChocolate.Id, result.Id);
        }

        [Fact]
        public void PurchasePringlesWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(50);
            Pringles expectedPringles = new Pringles();

            //Act
            Product result = vendingMashine.Purchase(3);
            
            //Assert
            Assert.Equal(expectedPringles.Id, result.Id);
        }

        [Fact]
        public void PurchaseWaterWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Water expectedWater = new Water();

            //Act
            Product result = vendingMashine.Purchase(2);
            
            //Assert
            Assert.Equal(expectedWater.Id, result.Id);
        }

        [Fact]
        public void PurchaseProductWithInsuffitientMoneyShouldThrowException()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(50);

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>(()=> vendingMashine.Purchase(2));

            //Assert
            Assert.Equal("The price of the product is high", result.Message);
        }

        [Fact]
        public void PurchaseProductWithIncorrectIdShouldThrowException()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);

            //Act
            ArgumentException result = Assert.Throws<ArgumentException>( ()=> vendingMashine.Purchase(0));

            //Assert
            Assert.Equal("Product is not found!", result.Message);
        }

        [Fact]

        public void EndTransactionWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(1);

            Dictionary<int, int> expectedChange = new Dictionary<int, int> { { 100, 4 }, { 50, 1 }, { 20, 2 }, { 5, 1 } };

            //Act
            Dictionary<int, int> result = vendingMashine.EndTransaction(product.Id);

            //Assert
            Assert.Equal(expectedChange, result);
        }

        [Fact]
        public void ChocolateExamineWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(1);

            string expected = $"1\tChocolate\t\t5kr";

            //Act
            string result = product.Examine();

            //Assert
            Assert.Equal(expected , result);
        }

        [Fact]
        public void WaterExamineWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(2);

            string expected = $"2\tWater\t\t\t100kr";

            //Act
            string result = product.Examine();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PringlesExamineWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(3);

            string expected = $"3\tPringles\t\t50kr";

            //Act
            string result = product.Examine();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ChocolateUseeWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(1);

            string expected = "It is a snack. Can be eated! But don't eat too many.. They are not good for your teeth. ";

            //Act
            string result = product.Use();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void WaterUseWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(2);

            string expected = "It is a drink. You can use it when you are thirsty!\n";

            //Act
            string result = product.Use();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PringlesUseWorkCorrectly()
        {
            //Arrange;
            VendingMachine vendingMashine = new VendingMachine();
            vendingMashine.InsertMoney(500);
            Product product = vendingMashine.Purchase(3);

            string expected = "You have got this product\n It is a snack. Can be eated!";

            //Act
            string result = product.Use();

            //Assert
            Assert.Equal(expected, result);
        }

    }
}
