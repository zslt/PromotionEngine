# PromotionEngine

# About

This is a .NET 5.0 promotion enginge library.

# Usage

## PromotionEngine

The main logic PromotionEngine (implenting the IPromotionEngine) is under the namesapce PromotionEngine.Library (implenting the IPromotionEngine).

Instatiation:
Parameters:
    IPromotionRepository (the IPromotionRepository implementaion has to return Promotion instances for an input or Product instances)
```
var promotionEngine = new PromotionEngine(promotionRepository);
```
Usage:
Parameters:
    IEnumerable<Product>
Returns: double (the discounted price part of the total cart price)
Example:
```
var result = promotionEngine.ApplyPromotions(
            new List<Product>()
            {
                new Product("A", 50)
            });
```

## Models

Promotion
Parameters:
    string sku
    double price
Example:
```
new Product("A", 50)
```

Promotion
Parameters:
    IDictionary<Product>
    Rule
Example:
```
new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));
```

Rule
Parameters:
    Operation
Example:
```
new Rule(Operation.Subtract, 20)
```