namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    abstract public class Product
    {
        public int  Id{ get; set; }
        public int Price { get; set; }

        public string Name { get; set; }

        public abstract string Examine();
        public abstract string Use();

    }
}