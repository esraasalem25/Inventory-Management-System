using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Classes
{
    internal class Supplier
    {
        List<Product> Supply;
        private static int supplierid = 0;
        private int Phone;
        private string email;
        public int SupplierId { get; }
        public string SupplierName { get; }
        public int PhoneNumber { get; }
        public string EMail { get; set; }
        public double Rating { get; }


        public Supplier(string name, int _phone, string _email, double rating = 4)
        {
            supplierid++;
            SupplierName = name;
            SupplierId = supplierid;
            EMail = _email;
            Phone = _phone;
            Rating = rating;
            Supply=new List<Product>();
        }
        public void AddProduct(Product p)
        {

            foreach (Product p2 in Supply)
            {
                if (p.Equals(p2))
                {
                    Console.WriteLine("The supplier already supplies this product");
                    break;
                }
            }
            Supply.Add(p);



        }
        public void RemoveProduct(Product p) 
        {
            bool found = false;
            foreach (Product p2 in Supply) 
            {
                if (p.Equals(p2)) 
                {
                    Supply.Remove(p);
                    found = true;
                }
                
            }
            if (found == false) 
            {
                Console.WriteLine("the supplier does not supply that product");
            }

        }
        public void RemoveProduct(int id)
        {
            bool found = false;
            foreach (Product p2 in Supply)
            {
                if (id==p2.ID)
                {
                    Supply.Remove(p2);
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("the supplier does not supply that product");
            }

        }
        public void RemoveProduct(string name)
        {
            bool found = false;
            foreach (Product p2 in Supply)
            {
                if (name==p2.Name)
                {
                    Supply.Remove(p2);
                    found = true;
                }

            }
            if (found == false)
            {
                Console.WriteLine("the supplier does not supply that product");
            }

        }
        public void GetRating() 
        {
            Console.WriteLine($"The supplier current rating is : {Rating}");
        }
        public void ProductsSupplied() 
        {
            foreach (Product p in Supply) 
            {
                Console.WriteLine(p.ToString());
            }    
        }
        public override string ToString()
        {
            return $"Name : {SupplierName } :: ID : {SupplierId} :: phone : {Phone} :: Email : {EMail}";
        }
    }
}
