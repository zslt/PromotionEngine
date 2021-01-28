using System;
using System.Collections.Generic;
using PromotionEngine.Library.Model;
using System.Linq;

namespace PromotionEngine.Library
{
    public class InMemoryPromotionRepository : IPromotionRepository
    {
        private readonly IList<Promotion> promotions;

        public InMemoryPromotionRepository(IList<Promotion> promotions)
        {
            this.promotions = promotions ?? throw new ArgumentNullException(nameof(promotions));
        }

        public IList<Promotion> GetPromotions(IList<Product> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return promotions
                .Where(x => products.Any(y => x.DiscountedProducts.ContainsKey(y)))
                .ToList();
        }
    }
}