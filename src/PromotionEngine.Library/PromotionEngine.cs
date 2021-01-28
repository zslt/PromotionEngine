using System;
using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Library.Model;

namespace PromotionEngine.Library
{
    public class PromotionEngine : IPromotionEngine
    {
        private readonly IPromotionRepository promotionRepository;

        public PromotionEngine(IPromotionRepository promtionRepositoy)
        {
            this.promotionRepository = promtionRepositoy ?? throw new ArgumentNullException(nameof(promtionRepositoy));
        }

        public double ApplyPromotions(IEnumerable<Product> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            if (!products.Any())
            {
                throw new ArgumentException(nameof(products));
            }

            var relevantPromotions = promotionRepository.GetPromotions(products);

            var discountableProducts = products
                .Select(x => new DiscountableProduct(x.Sku, x.Price))
                .ToList();

            return relevantPromotions.Sum(x => x.Apply(discountableProducts))
                + discountableProducts.Where(x => !x.Discounted).Sum(x => x.Price);
        }
    }
}