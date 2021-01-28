using System;
using System.Collections.Generic;

namespace PromotionEngine.Library
{
    public class PromotionRepository : IPromotionRepository
    {
        public IList<Promotion> GetPromotions(IList<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}