using Inventory.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace Inventory.Classes
{
    public class FileManager
    {
      
        internal void SaveProducts(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter("products.txt"))
            {
                foreach (Product p in products)
                {
                    
                    writer.WriteLine($"{p.Name}|{p.Price}|{p.Description}|{p.Category}|{p.Quantity}");
                }
            }
        }

        internal List<Product> LoadProducts()  
        {
            List<Product> products = new List<Product>();

            if (!File.Exists("products.txt"))
                return products;

            string[] lines = File.ReadAllLines("products.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    Product product = new Product(
                        price: int.Parse(parts[1]),
                        name: parts[0],
                        description: parts[2],
                        category: (Category)Enum.Parse(typeof(Category), parts[3]),
                        quantity: int.Parse(parts[4])
                    );

                    products.Add(product);
                }
            }

            return products;
        }
    }
}