namespace Magazin_online.controllers
{
    public class ControllerProductBase
    {
        public void Display(List<Product> list)
        {
            foreach (Product p in list)
            {
                Console.WriteLine(p.description());
            }
        }
    }
}