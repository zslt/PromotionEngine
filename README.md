# PromotionEngine

# About

This is a .NET 5.0 promotion enginge library.

# Usage

## PromotionEngine

The main logic PromotionEngine (implenting the IPromotionEngine) is under the namesapce PromotionEngine.Library (implenting the IPromotionEngine).

Instatiation:<br />
Parameters:<br />
    IPromotionRepository (the IPromotionRepository implementaion has to return Promotion instances for an input or Product instances)
```
var promotionEngine = new PromotionEngine(promotionRepository);
```
Usage:<br />
Parameters:<br />
    IEnumerable<Product><br />
Returns: double (the discounted price part of the total cart price)<br />
Example:<br />
```
var result = promotionEngine.ApplyPromotions(
            new List<Product>()
            {
                new Product("A", 50)
            });
```

## Models

Promotion<br />
Parameters:<br />
    string sku<br />
    double price<br />
Example:<br />
```
new Product("A", 50)
```

Promotion<br />
Parameters:<br />
    IDictionary<Product><br />
    Rule<br />
Example:
```
new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));
```

Rule<br />
Parameters:<br />
    Operation<br />
Example:<br />
```
new Rule(Operation.Subtract, 20)
```
