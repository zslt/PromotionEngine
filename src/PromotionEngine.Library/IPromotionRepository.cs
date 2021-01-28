using System;
using System.Collections.Generic;
using PromotionEngine.Library.Model;

namespace PromotionEngine.Library
{
    public interface IPromotionRepository
    {
        IList<Promotion> GetPromotions(IEnumerable<Product> products);
    }
}