using Inventory.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Classes
{
    internal class Product
    {
        private static int product_id=0;
        public int Price { get;}
        public int ID { get; }
        public string Name { get;}
        public string Description { get;}

        public Category Category { get;}

        public int Quantity{ get; set; }

        public Product(int price=10, string name="",string description="",Category category=Category.Unknown,int quantity=0) 
        {
            product_id++;
            ID = product_id;
            Price = price;
            Name = name;
            Description = description;
            Category =category;
            Quantity=quantity;
        }
        public override string ToString()
        {
            return $"{ID}::{Name}::{Quantity}::{Price:c}";
        }
        public override bool Equals(Object j)
        {
            if(j is Product p) 
            {
                return this.ID == p.ID;
            }
            return false ;

        }
    }
}
