# PromotionEngine

# About

This is a .NET 5.0 promotion engine library.

# Usage

## PromotionEngine

The main logic PromotionEngine (implenting the IPromotionEngine) is under the namesapce PromotionEngine.Library (implenting the IPromotionEngine).

Instatiation:<br />
Parameters:<br />
&nbsp;&nbsp;&nbsp;IPromotionRepository (the IPromotionRepository implementaion has to return Promotion instances for an input or Product instances)
```
var promotionEngine = new PromotionEngine(promotionRepository);
```
Usage:<br />
Parameters:<br />
&nbsp;&nbsp;&nbsp;IEnumerable\<Product\><br />
Returns: decimal (the discounted price part of the total cart price)<br />
Example:<br />
```
var result = promotionEngine.ApplyPromotions(
            new List<Product>()
            {
                new Product("A", 50)
            });
```

## Models

Product<br />
Parameters:<br />
&nbsp;&nbsp;&nbsp;string sku<br />
&nbsp;&nbsp;&nbsp;decimal price<br />
Example:<br />
```
new Product("A", 50)
```

Promotion<br />
Parameters:<br />
&nbsp;&nbsp;&nbsp;IDictionary\<Product\> products<br />
&nbsp;&nbsp;&nbsp;Rule rule<br />
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
&nbsp;&nbsp;&nbsp;Operation operation<br />
&nbsp;&nbsp;&nbsp;decimal value<br />
Example:<br />
```
new Rule(Operation.Subtract, 20)
```
