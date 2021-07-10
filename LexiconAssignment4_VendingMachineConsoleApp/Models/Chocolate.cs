using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    class Chocolate : Product
    {
        public Chocolate()
        {
            Id = 1;
            Name = "Chocolate";
            Price = 5;
        }

        public override string Examine()
        {
            return $"{Id}\t{Name}\t\t{Price}Kr"; ;
        }

        public override string Use()
        {
            return "It is a snack. Can be eated! But don't eat too many.. They are not good for your teeth. ";
        }

    }
}
