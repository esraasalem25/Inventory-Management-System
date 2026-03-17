using System;
using System.Collections.Generic;
using Inventory.Classes;
using Inventory.Enums;

namespace Inventory.Services
{
    internal class ReportsManager
    {
        public void ShowAllSales(List<Transaction> transactions)
        {
            Console.WriteLine("\nALL SALES REPORT");
            if (transactions.Count == 0)
            {
                Console.WriteLine("No sales yet.");
                return;
            }

            foreach (Transaction t in transactions)
                Console.WriteLine(t.ToString());
        }

        public double GetTotalSales(List<Transaction> transactions)
        {
            double total = 0;
            foreach (Transaction t in transactions)
                total += t.FinalTotal;

            return total;
        }

        public void ShowTotalSales(List<Transaction> transactions)
        {
            Console.WriteLine($"\nTotal Sales = {GetTotalSales(transactions):c}");
        }

        public void ShowBestSeller(List<Transaction> transactions)
        {
            Console.WriteLine("\nBEST SELLER");

            if (transactions.Count == 0)
            {
                Console.WriteLine("No sales yet.");
                return;
            }

            Dictionary<int, int> salesCount = new Dictionary<int, int>();

            foreach (Transaction t in transactions)
            {
                int id = t.Product.ID;
                if (salesCount.ContainsKey(id))
                    salesCount[id] += t.QuantitySold;
                else
                    salesCount[id] = t.QuantitySold;
            }

            int bestId = -1;
            int max = 0;

            foreach (var item in salesCount)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    bestId = item.Key;
                }
            }

            foreach (Transaction t in transactions)
            {
                if (t.Product.ID == bestId)
                {
                    Console.WriteLine($"Best Seller: {t.Product.Name}");
                    Console.WriteLine($"Units Sold: {max}");
                    Console.WriteLine($"Category: {t.Product.Category}");
                    Console.WriteLine($"Price: {t.Product.Price:c}");
                    break;
                }
            }
        }


        public void ShowSalesByDate(List<Transaction> transactions, DateTime date)
        {
            Console.WriteLine($"\nSALES ON {date.ToShortDateString()}");

            bool found = false;
            foreach (Transaction t in transactions)
            {
                if (t.Date.Date == date.Date)
                {
                    Console.WriteLine(t.ToString());
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No sales on this date.");
        }


        public void ShowSalesBetweenDates(List<Transaction> transactions, DateTime from, DateTime to)
        {
            Console.WriteLine($"\nSALES FROM {from.ToShortDateString()} TO {to.ToShortDateString()}");

            bool found = false;
            foreach (Transaction t in transactions)
            {
                if (t.Date.Date >= from.Date && t.Date.Date <= to.Date)
                {
                    Console.WriteLine(t.ToString());
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No sales in this date range.");
        }


        public void ShowSalesByCategory(List<Transaction> transactions, Category category)
        {
            Console.WriteLine($"\nSALES IN CATEGORY: {category}");

            bool found = false;
            foreach (Transaction t in transactions)
            {
                if (t.Product.Category == category)
                {
                    Console.WriteLine(t.ToString());
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No sales in this category.");
        }


        public void ShowProductSalesSummary(List<Transaction> transactions)
        {
            Console.WriteLine("\nPRODUCT SALES SUMMARY");

            if (transactions.Count == 0)
            {
                Console.WriteLine("No sales yet.");
                return;
            }

            Dictionary<int, int> salesCount = new Dictionary<int, int>();

            foreach (Transaction t in transactions)
            {
                int id = t.Product.ID;
                if (salesCount.ContainsKey(id))
                    salesCount[id] += t.QuantitySold;
                else
                    salesCount[id] = t.QuantitySold;
            }

            foreach (var item in salesCount)
            {
                foreach (Transaction t in transactions)
                {
                    if (t.Product.ID == item.Key)
                    {
                        Console.WriteLine($"{t.Product.Name} | Sold: {item.Value} | Category: {t.Product.Category}");
                        break;
                    }
                }
            }
        }


        public double GetEstimatedProfit(List<Transaction> transactions)
        {
            double profit = 0;
            foreach (Transaction t in transactions)
                profit += t.FinalTotal;

            return profit;
        }

        public void ShowEstimatedProfit(List<Transaction> transactions)
        {
            Console.WriteLine($"\nEstimated Profit = {GetEstimatedProfit(transactions):c}");
        }

        public void ShowLowStockProducts(List<Product> products, int threshold)
        {
            Console.WriteLine($"\nLOW STOCK PRODUCTS (Below {threshold})");

            bool found = false;
            foreach (Product p in products)
            {
                if (p.Quantity < threshold)
                {
                    Console.WriteLine($"{p.Name} | Qty: {p.Quantity} | Category: {p.Category}");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No low stock products.");
        }

        public void ShowFullReport(List<Transaction> transactions, List<Product> products)
        {

            Console.WriteLine("        INVENTORY FULL REPORT         ");

            ShowAllSales(transactions);
            ShowTotalSales(transactions);
            ShowEstimatedProfit(transactions);
            ShowBestSeller(transactions);
            ShowProductSalesSummary(transactions);
            ShowLowStockProducts(products, 5);


        }
    }
}
