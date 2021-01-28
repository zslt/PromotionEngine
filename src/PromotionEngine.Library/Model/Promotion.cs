using System;
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngine.Library.Model
{
    public class Promotion
    {
        private readonly Rule rule;        

        internal IDictionary<Product, int> DiscountedProducts { get; }

        public Promotion(IDictionary<Product, int> discountedProducts, Rule rule)
        {
            DiscountedProducts = discountedProducts ?? throw new ArgumentNullException(nameof(discountedProducts));
            this.rule = rule ?? throw new ArgumentNullException(nameof(rule));
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
                .ToDictionary(x => x.Key as Product, x => x.Count());

            var ruleApplicationNumber = DiscountedProducts
                .All(x => originalQuantityPerProduct.ContainsKey(x.Key))
                ? DiscountedProducts.Select(x => originalQuantityPerProduct[x.Key] / x.Value).Min()
                : 0;

            FlagDiscountedProducts(DiscountedProducts
                .ToDictionary(x => x.Key as Product, x => x.Value * ruleApplicationNumber),
                products);

            return rule.Apply(
                DiscountedProducts.Select(x => x.Key.Price * x.Value).Sum(),
                ruleApplicationNumber);
        }

        private void FlagDiscountedProducts(
            Dictionary<Product, int> dicountedQunatityPerProduct,
            IList<DiscountableProduct> products)
        {
            foreach (var product in products)
            {
                if (!product.Discounted
                    && dicountedQunatityPerProduct.ContainsKey(product)
                    && dicountedQunatityPerProduct[product] > 0)
                {
                    product.Discounted = true;
                    dicountedQunatityPerProduct[product] -= 1;
                }
            }
        }
    }
}