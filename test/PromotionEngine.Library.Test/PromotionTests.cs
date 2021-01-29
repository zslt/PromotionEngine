using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngine.Library;
using PromotionEngine.Library.Model;

namespace PromotionEngine.Library.Tests
{
    public class PromotionTests
    {
        [Test]
        public void Subtract_promotion_applied_for_a_product()
        {
            // Arrange
            var promotion = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 1 }
                },
                new Rule(Operation.Subtract, 20));

            // Act
            var result = promotion.Apply(
                new List<DiscountableProduct>()
                {
                    new DiscountableProduct("A", 50)
                });

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void Multiply_promotion_applied_for_a_product()
        {
            // Arrange
            var promotion = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 1 }
                },
                new Rule(Operation.Multiply, 0.5));

            // Act
            var result = promotion.Apply(
                new List<DiscountableProduct>()
                {
                    new DiscountableProduct("A", 50)
                });

            // Assert
            Assert.AreEqual(25, result);
        }

        [Test]
        public void No_promotion_applied_for_a_product()
        {
            // Arrange
            var promotion = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 2 }
                },
                new Rule(Operation.Subtract, 20));

            // Act
            var result = promotion.Apply(
                new List<DiscountableProduct>()
                {
                    new DiscountableProduct("A", 50)
                });

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}