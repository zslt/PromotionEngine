using System;
using System.Collections.Generic;

namespace PromotionEngine.Library
{
    public interface IPromotionEngine
    {
        double ApplyPromotions(IList<Product> products);
    }
}