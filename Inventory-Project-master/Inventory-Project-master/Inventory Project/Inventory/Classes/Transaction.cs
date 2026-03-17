namespace Inventory.Classes
{
    internal class Transaction
    {
        private static int transactionCounter = 0;

        public int Id { get; }
        public Product Product { get; }
        public int QuantitySold { get; }
        public double OriginalTotal { get; }
        public double FinalTotal { get; }
        public DateTime Date { get; }

        public Transaction(Product product, int quantity, double originalTotal, double finalTotal)
        {
            transactionCounter++;
            Id = transactionCounter;
            Product = product;
            QuantitySold = quantity;
            OriginalTotal = originalTotal;
            FinalTotal = finalTotal;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID:{Id} | {Product.Name} | Qty:{QuantitySold} | Before:{OriginalTotal:c} | After:{FinalTotal:c} | {Date}";
        }
    }
}

