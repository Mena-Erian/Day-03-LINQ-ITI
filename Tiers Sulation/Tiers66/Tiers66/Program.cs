namespace Tiers66
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = DataBusinessLayer.DepartmentManager.GetAll();

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
