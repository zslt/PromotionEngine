using System;

namespace PromotionEngine.Library.Model
{
    internal class DiscountableProduct : Product
    {
        public bool Discounted { get; set; }

        public DiscountableProduct(string sku, double price, bool discounted = false) : base(sku, price)
        {
            Discounted = discounted;
        }
    }
}