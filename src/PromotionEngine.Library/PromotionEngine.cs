using System;
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

        double ApplyPromotions(IList<Product> products) => 0;
    }
}