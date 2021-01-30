using System;

namespace PromotionEngine.Library.Model
{
    public class Product
    {
        public string Sku { get; }

        public decimal Price { get; }

        public Product(string sku, decimal price)
        {
            Sku = sku ?? throw new ArgumentNullException(nameof(sku));
            Price = price;
        }

        public override bool Equals(object obj) => 
            obj is Product && this == (Product)obj;

        public override int GetHashCode() => (Sku, Price).GetHashCode();
        
        public static bool operator ==(Product x, Product y) =>
            x.Sku == y.Sku && x.Price == y.Price;
        
        public static bool operator !=(Product x, Product y) => !(x == y);
    }
}