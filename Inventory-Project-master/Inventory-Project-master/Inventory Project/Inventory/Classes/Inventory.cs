using Inventory.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Inventory.Classes
{
    internal class Inventoryy
    {
        private static List<Product> products = new List<Product>();

        public Inventoryy()
        {

        }
        public void AddProducts(List<Product> List) //accept list loaded from the file manager load method
        {
            foreach (Product Product in List) 
            {
                products.Add(Product);
            }
        }
        public void AddProduct(Product p)
        {
            if (products.Contains(p))
            {
                Console.WriteLine("This product already exists");
            }

            else
            {
                products.Add(p);
            }
        }
        public void RemoveProduct(Product p)
        {
            products.Remove(p);
        }
        public void RemoveProduct(string name)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (p.Name == name)
                {
                    products.Remove(p);
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("There were no products with that name");
            }

        }
        public void RemoveProduct(int id)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (p.ID == id)
                {
                    products.Remove(p);
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("There were no products with that ID");
            }

        }
        public void ShowProducts()
        {
            foreach (Product p in products)
            {
                Console.WriteLine($"Name = {p.Name} , Quantity ={p.Quantity},Price ={p.Price:c}");
            }
        }
        public void ShowProducts(Category c)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (p.Category == c)
                {
                    Console.WriteLine($"Name = {p.Name} , Quantity ={p.Quantity},Price ={p.Price:c}");
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("There were no products in that category");
            }
        }
        public void LowStock(int stock)
        {
            foreach (Product p in products)
            {
                if (p.Quantity < stock)
                {
                    Console.WriteLine($"Name = {p.Name} , Quantity ={p.Quantity}");
                }
            }
        }
        public void LowStock(int stock, Category c)
        {
            foreach (Product p in products)
            {
                if (p.Quantity < stock && p.Category == c)
                {
                    Console.WriteLine($"Name = {p.Name} , Quantity ={p.Quantity}");
                }
            }
        }
        public void AddStock(Product p, int q)
        {
            bool found = false;
            foreach (Product pro in products)
            {
                if (pro == p)
                {
                    if (q > 0)
                    {
                        p.Quantity += q;
                        found = true;
                    }
                    else
                    {
                        Console.WriteLine("you must add a positive number");
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("The product does not exist");
            }
        }
        public void AddStock(string name, int q)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (p.Name == name)
                {
                    if (q > 0)
                    {
                        found = true;
                        p.Quantity += q;
                    }
                    else
                    {
                        Console.WriteLine("you must add a positive number");
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("There is no product with that name");
            }
        }
        public void AddStock(int id, int q)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (p.ID == id)
                {
                    if (q > 0)
                    {
                        found = true;
                        p.Quantity += q;
                    }
                    else
                    {
                        Console.WriteLine("you must add a positive number");
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("There is no product with that ID");
            }
        }
        public void RemoveStock(Product p, int i)
        {
            if (i < 0)
            {
                Console.WriteLine("please enter a postive number");
            }
            else if (i > p.Quantity)
            {
                Console.WriteLine("There is no enough stock available");
            }
            else
            {
                p.Quantity -= i;
            }
        }
        public void SearchProduct(string name)
        {
            bool found = false;
            foreach (Product p in products)
            {

                if (name == p.Name)
                {
                    Console.WriteLine($"Name= {p.Name}::Id={p.ID}::quantity={p.Quantity}:: price= {p.Price:c}");
                    found = true;
                }


            }
            if (found == false)
            {
                Console.WriteLine("No product matches this name");

            }
        }
        public void SearchProduct(int id)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (id == p.ID)
                {
                    Console.WriteLine($"Name= {p.Name}::Id={p.ID}::quantity={p.Quantity}:: price= {p.Price:c}");
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("No matching was found");
            }
        }
        public Product GetProductById(int id)
        {
            bool found = false;
            foreach (Product p in products)
            {
                
                if (id == p.ID)
                {
                    Console.WriteLine($"Name= {p.Name}::Id={p.ID}::quantity={p.Quantity}:: price= {p.Price:c}");
                    found = true;
                   return p;
                }
                return null;
            }
           
            if (found == false)
            {
                Console.WriteLine("No matching was found");
                return null;
            }
            return null;
        }

        public void SearchProduct(Product product)
        {
            bool found = false;
            foreach (Product p in products)
            {
                if (product == p)
                {
                    Console.WriteLine($"Name= {p.Name}::Id={p.ID}::quantity={p.Quantity}:: price= {p.Price:c}");
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("No matching was found");
            }
        }
        public List<Product> ReturnProducts() 
        {
            return products;
        }

    }
}
