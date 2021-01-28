using NUnit.Framework;

namespace PromotionEngine.Library.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Three_identical_products_in_one_promotion()
        {
            //Unit price for SKU IDs            
            //A 50
            //B 30
            //C 20
            //D 15

            //Active Promotions
            //3 of A for 130
            //2 of B for 45
            //C and D for 30
            
            //Scenario A
            //1 * A 50
            //1 * B 30
            //1 * C 20

            // Assert 100
            
            Assert.Pass();
        }

        [Test]
        public void Three_identical_products_in_one_promotion()
        {
            //Unit price for SKU IDs            
            //A 50
            //B 30
            //C 20
            //D 15

            //Active Promotions
            //3 of A for 130
            //2 of B for 45
            //C and D for 30
            
            //Scenario B
            //5 * A 130 + 2*50
            //5 * B 45 + 45 + 30
            //1 * C 28

            // Assert 370
            
            Assert.Pass();
        }

        [Test]
        public void Two_identical_products_in_one_promotion()
        {
            //Unit price for SKU IDs            
            //A 50
            //B 30
            //C 20
            //D 15

            //Active Promotions
            //3 of A for 130
            //2 of B for 45
            //C and D for 30
            
            //Scenario A
            //1 * A 50
            //1 * B 30
            //1 * C 20

            // Assert 100
            
            Assert.Pass();
        }

        [Test]
        public void Two_different_products_in_one_promotion()
        {
            //Unit price for SKU IDs            
            //A 50
            //B 30
            //C 20
            //D 15

            //Active Promotions
            //3 of A for 130
            //2 of B for 45
            //C and D for 30
            
            //Scenario C
            //3 * A 130
            //5 * B 45 + 45 + 1 * 30
            //1 * C -
            //1 * D 30

            // Assert 380
            
            Assert.Pass();
        }
    }
}