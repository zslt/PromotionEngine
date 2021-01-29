using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using PromotionEngine.Library;
using PromotionEngine.Library.Model;

namespace PromotionEngine.Library.Tests
{
    public class PromotionEngineTests
    {
        [Test]
        public void Three_identical_products_in_one_promotion()
        {
            // Arrange
            var promotion1 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));
            var promotion2 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("B", 30), 2 }
                },
                new Rule(Operation.Subtract, 15));
            var promotion3 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("C", 20), 1 },
                    { new Product("D", 15), 1 }
                },
                new Rule(Operation.Subtract, 5));

            var promotionRepository = new InMemoryPromotionRepository(
                new List<Promotion>() {promotion1, promotion2, promotion3});
            
            var promotionEngine = new PromotionEngine(promotionRepository);

            // Act
            var result = promotionEngine.ApplyPromotions(
                new List<Product>()
                {
                    new Product("A", 50),
                    new Product("B", 30),
                    new Product("C", 20)
                });

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void Identical_products_in_one_promotion_mulitple_times()
        {
            // Arrange
            var promotion1 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));
            var promotion2 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("B", 30), 2 }
                },
                new Rule(Operation.Subtract, 15));
            var promotion3 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("C", 20), 1 },
                    { new Product("D", 15), 1 }
                },
                new Rule(Operation.Subtract, 5));

            var promotionRepository = new InMemoryPromotionRepository(
                new List<Promotion>() {promotion1, promotion2, promotion3});
            
            var promotionEngine = new PromotionEngine(promotionRepository);

            // Act
            var result = promotionEngine.ApplyPromotions(
                new List<Product>()
                {
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("C", 20)
                });

            // Assert
            Assert.AreEqual(370, result);
        }

        [Test]
        public void Two_different_products_in_one_promotion()
        {
            // Arrange
            var promotion1 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));
            var promotion2 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("B", 30), 2 }
                },
                new Rule(Operation.Subtract, 15));
            var promotion3 = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("C", 20), 1 },
                    { new Product("D", 15), 1 }
                },
                new Rule(Operation.Subtract, 5));

            var promotionRepository = new InMemoryPromotionRepository(
                new List<Promotion>() {promotion1, promotion2, promotion3});
            
            var promotionEngine = new PromotionEngine(promotionRepository);

            // Act
            var result = promotionEngine.ApplyPromotions(
                new List<Product>()
                {
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("B", 30),
                    new Product("C", 20),
                    new Product("D", 15)
                });

            // Assert
            Assert.AreEqual(280, result);
        }

        [Test]
        public void No_promotion_found_for_products()
        {
            // Arrange
            var promotion = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));

            var promotionRepository = new InMemoryPromotionRepository(
                new List<Promotion>() {promotion });
            
            var promotionEngine = new PromotionEngine(promotionRepository);

            // Act
            var result = promotionEngine.ApplyPromotions(
                new List<Product>()
                {
                    new Product("B", 30),
                });

            // Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void All_products_discounted()
        {
            // Arrange
            var promotion = new Promotion(
                new Dictionary<Product, int>()
                {
                    { new Product("A", 50), 3 }
                },
                new Rule(Operation.Subtract, 20));

            var promotionRepository = new InMemoryPromotionRepository(
                new List<Promotion>() {promotion });
            
            var promotionEngine = new PromotionEngine(promotionRepository);

            // Act
            var result = promotionEngine.ApplyPromotions(
                new List<Product>()
                {
                    new Product("A", 50),
                    new Product("A", 50),
                    new Product("A", 50)
                });

            // Assert
            Assert.AreEqual(130, result);
        }
    }
}