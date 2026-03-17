using Inventory.Classes;
using Inventory.Enums;
using Inventory.Services;

namespace Inventory
{
    internal class Program
    {
        static void AddProductMenu(Inventoryy i)
        {

            Console.WriteLine("Enter product name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The quantity ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Slect category");
            foreach (var j in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine((int)j);
            }
            int category = int.Parse(Console.ReadLine());
            Category g = (Category)category;
            Product product = new Product(price, name, "no description", g, quantity);
            i.AddProduct(product);


        }
        static void SellProductMenu(Inventoryy i, SalesManager s)
        {
            Console.WriteLine("Enter products id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantity");
            int q = int.Parse(Console.ReadLine());
            Product p = i.GetProductById(id);
            if (p == null)
            {
                return;
            }
            s.SellProduct(p, q);
        }
        static void Main(string[] args)

        {
            FileManager fileManager = new FileManager();
            Inventoryy inventory = new Inventoryy();
            List<Product> products = fileManager.LoadProducts();
            inventory.AddProducts(products);    
            


            SalesManager salesManager = new SalesManager();
            bool running = true;
            Console.WriteLine("press 1 : to add product");
            Console.WriteLine("press 2 : to show products");
            Console.WriteLine("press 3 : to buy products");
            Console.WriteLine("press 4 : to get total sales ");
            Console.WriteLine("press 5 : to get best seller ");
            Console.WriteLine("press 6 : to get out ");
            ReportsManager reportsManager = new ReportsManager();

            List<Transaction> transactions = new List<Transaction>
{

    new Transaction(
        product: products[0],
        quantity: 2,
        originalTotal: 1998.00,
        finalTotal: 1798.20
    ),


    new Transaction(
        product: products[1],
        quantity: 3,
        originalTotal: 2397.00, // 3 * 799
        finalTotal: 2277.15     // 5% discount
    ),
    
    // Transaction 3: Selling 5 headphones at full price (no discount)
    new Transaction(
        product: products[2],
        quantity: 5,
        originalTotal: 995.00,  
        finalTotal: 995.00      
    ),
    
  
    new Transaction(
        product: products[4],
        quantity: 10,
        originalTotal: 890.00,  
        finalTotal: 801.00      
    ) };


            while (running)
            {

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProductMenu(inventory); break;
                    case "2":
                        inventory.ShowProducts(); break;
                    case "3":
                        SellProductMenu(inventory, salesManager); break;
                    case "4":
                        salesManager.GetTotalSales(); break;
                    case "5":
                        salesManager.GetBestSeller(); break;
                    case "6":
                        reportsManager.ShowAllSales(transactions); break;

                    case "0": running = false; break;




                }
            }

        }
    }
}
