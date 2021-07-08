namespace LexiconAssignment4_VendingMachineConsoleApp.Models
{
    abstract public class Product
    {
        public int  Id{ get; set; }
        public int Price { get; set; }

        public abstract void Examine();
        public abstract void USe();
    }
}