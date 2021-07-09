using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    class Pringles : Product
    {
        public Pringles() : base()
        {
            Id = 3;
            Name = "Pringles";
            Price = 50;
        }
        public override string Examine()
        {
            return $"{Id}\t{Name}\t\t{Price}kr"; 
        }

        public override string Use()
        {
            return "You have got this product\nUse: It is a snack. Can be eated!";
        }

    }
}
