using System;
using System.Linq;

namespace PromotionEngine.Library.Model
{
    public class Promotion
    {
        private readonly Rule rule;        

        public IDictionary<Product, int> DiscountedProducts { get; }

        public Promotion(Rule rule, IDictionary<Product, int> discountedProducts)
        {
            this.rule = rule ?? throw new ArgumentNullException(nameof(rule));
            DiscountedProducts = discountedProducts ?? throw new ArgumentNullException(nameof(discountedProducts));
        }

        internal double Apply(IList<DiscountableProduct> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var originalQuantityPerProduct = products
                .Where(x => !x.Discounted)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            var ruleApplicationNumber = DiscountedProducts
                .All(x => originalQuantityPerProduct.ContainsKey(x.Key))
                ? DiscountedProducts.Select(x => originalQuantityPerProduct[x.Key] / x.Value).Min()
                : 0;

            var dicountedQunatityPerProduct = DiscountedProducts
                .ToDictionary(x => x.Key, x => x.Value * ruleApplicationNumber);

            foreach (var product in products)
            {
                if (!product.Discounted
                    && dicountedQunatityPerProduct.ContainsKey(prod)
                    && dicountedQunatityPerProduct[prod] > 0)
                {
                    product.Discounted = true;
                    dicountedQunatityPerProduct[prod] += 1;
                }
            }

            return rule.Apply(
                DiscountedProducts.Select(x => x.Key.Price * x.Value).Sum(),
                ruleApplicationNumber);
        }
    }
}