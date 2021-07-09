using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    class Water : Product
    {
        public Water()
        {
            Id = 2;
            Name = "Water";
            Price = 100;
        }
        public override string Examine()
        {
            return $"{Id}\t{Name}\t\t\t{Price}kr\n"; 
        }

        public override string Use()
        {
            return "Use: It is a drink. Drink it when you are thirsty!\n";
        }
    }
}
