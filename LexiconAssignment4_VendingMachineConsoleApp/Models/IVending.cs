using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    interface IVending
    {
        //to buy a product
        Product Purchase(int id);

        //show all products.
        Product[] ShowAll();

        //add money to the pool.
        void InsertMoney(int amount);

        //returns money left in appropriate amount of change(Dictionary).
        Dictionary<int,int> EndTransaction();


    }
}
