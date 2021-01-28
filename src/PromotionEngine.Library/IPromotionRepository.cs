using System;
using System.Collections.Generic;

namespace PromotionEngine.Library
{
    public interface IPromotionRepository
    {
        IList<Promotion> GetPromotions(IList<Product> products);
    }
}