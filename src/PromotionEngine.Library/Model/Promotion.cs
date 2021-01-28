using System;

namespace PromotionEngine.Library.Model
{
    public class Promotion
    {
        private readonly Rule rule;        

        public IDictionary<Product, int> DiscountableProducts { get; }

        public Promotion(Rule rule, IDictionary<Product, int> discountableProducts)
        {
            this.rule = rule ?? throw new ArgumentNullException(nameof(rule));
            DiscountableProducts = discountableProducts ?? throw new ArgumentNullException(nameof(discountableProducts));
        }

        public double Apply(IList<Product> products) => 0;
    }
}