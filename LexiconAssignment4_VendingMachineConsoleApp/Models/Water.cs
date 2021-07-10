using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    public class Water : Product
    {
        public Water()
        {
            Id = 2;
            Name = "Water";
            Price = 100;
        }
        public override string Examine()
        {
            return $"{Id}\t{Name}\t\t\t{Price}kr"; 
        }

        public override string Use()
        {
            return "It is a drink. You can use it when you are thirsty!\n";
        }
    }
}
