using Inventory.Classes;
using Inventory.Enums;

namespace Inventory
{
    internal class DiscountManager
    {
        public double ApplyDiscount(Product product, int quantity)
        {
            if (product == null || quantity <= 0)
                return 0;

            double total = product.Price * quantity;

            if (quantity >= 10)
                total *= 0.80;
            else if (quantity >= 5)
                total *= 0.90;

            if (product.Category == Category.Food || product.Category == Category.Beverages)
                total *= 0.95;

            return total;
        }
    }
}


