﻿using System;
using System.Collections.Generic;
using PromotionEngine.Library.Model;

namespace PromotionEngine.Library
{
    public interface IPromotionEngine
    {
        double ApplyPromotions(IList<Product> products);
    }
}