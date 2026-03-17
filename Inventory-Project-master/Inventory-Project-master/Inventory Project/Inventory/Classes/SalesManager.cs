using Inventory.Classes;

namespace Inventory
{
    internal class SalesManager
    {
        private List<Transaction> transactions;
        private DiscountManager discountManager;

        public SalesManager()
        {
            transactions = new List<Transaction>();
            discountManager = new DiscountManager();
        }

        public void SellProduct(Product product, int quantity)
        {
            if (product == null)
            {
                Console.WriteLine("Invalid product.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Please enter a positive quantity.");
                return;
            }

            if (product.Quantity < quantity)
            {
                Console.WriteLine("Not enough stock available.");
                return;
            }

            double originalTotal = product.Price * quantity;
            double finalTotal = discountManager.ApplyDiscount(product, quantity);

            Transaction t = new Transaction(product, quantity, originalTotal, finalTotal);
            transactions.Add(t);

            product.Quantity -= quantity;

            Console.WriteLine($"Sold {quantity} of {product.Name}. Final Total: {finalTotal:c}");
        }

        public double GetTotalSales()
        {
            double total = 0;
            foreach (Transaction t in transactions)
                total += t.FinalTotal;

            return total;
        }

        public void ShowAllTransactions()
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
                return;
            }

            foreach (Transaction t in transactions)
                Console.WriteLine(t);
        }

        public void GetBestSeller()
        {
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
                    Console.WriteLine($"Best Seller: {t.Product.Name} with {max} sold.");
                    break;
                }
            }
        }
    }
}

