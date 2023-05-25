using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class ViksWaresTest
    {
        //Unit Tests: Normal Items

        [Test]
        public void UpdateItemSellByValue_NormalItem_ValueDecreaseByOne()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Torch",
                    SellBy = 3,
                    Value = 1
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(0, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_NormalItem_SellByDecreaseByOne()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Pickaxe",
                    SellBy = 5,
                    Value = 7
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(4, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_NormalItem_ValueAndSellByDecreaseByOne()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Can",
                    SellBy = 7,
                    Value = 12
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(6, Items[0].SellBy);
            Assert.AreEqual(11, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_NormalItem_ValueDecreasesTwiceWhenSellByPasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Cards",
                    SellBy = -1,
                    Value = 25
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(23, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_NormalItem_ValueAlwaysPositive()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Mouse",
                    SellBy = -1,
                    Value = 1
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(0, Items[0].Value);
        }

        //Unit Tests: Normal Items - User Errors

        [Test]
        public void UpdateItemSellByValue_NormalItemUserError_ValueNotMoreThanFifty()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Shampoo",
                    SellBy = 10,
                    Value = 52
                }
            };

            ViksWares app = new ViksWares(Items);
            
            Assert.That(app.UpdateItemSellByValue, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateItemSellByValue_NormalItemUserError_ItemWithEmptyName()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "   ",
                    SellBy = 7,
                    Value = 26
                }
            };

            ViksWares app = new ViksWares(Items);
                
            Assert.That(app.UpdateItemSellByValue, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateItemSellByValue_NormalItemUserError_ItemWithNullName()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = null,
                    SellBy = 4,
                    Value = 32
                }
            };

            ViksWares app = new ViksWares(Items);

            Assert.That(app.UpdateItemSellByValue, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateItemSellByValue_NormalItemUserError_ValueAlwaysPositive()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Mouse",
                    SellBy = 2,
                    Value = -1
                }
            };

            ViksWares app = new ViksWares(Items);

            Assert.Throws<ArgumentException>(() => app.UpdateItemSellByValue());
        }
        
        //Unit Tests: Aged Parmigiano

        [Test]
        public void UpdateItemSellByValue_AgedParmigiano_ValueIncreasesWhenSellByDecreases()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Parmigiano",
                    SellBy = 7,
                    Value = 5
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(6, Items[0].Value);
            Assert.AreEqual(6, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_AgedParmigiano_ValueNotMoreThanFifty()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Parmigiano",
                    SellBy = 10,
                    Value = 50
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(50, Items[0].Value);
        }

        //UnitTests: Saffron Powder

        [Test]
        public void UpdateItemSellByValue_SaffronPowder_ValueNotDecreasing()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = -1,
                    Value = 80
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(80, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_SaffronPowder_ValueAndSellByNotDecreasing()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = -1,
                    Value = 80
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(-1, Items[0].SellBy);
            Assert.AreEqual(80, Items[0].Value);
        }

        //Unit Tests: Saffron Powder - User Errors

        [Test]
        public void UpdateItemSellByValue_SaffronPowderUserError_SellByAlwaysMinusOne()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 1,
                    Value = 80
                }
            };

            ViksWares app = new ViksWares(Items);

            Assert.Throws<ArgumentException>(() => app.UpdateItemSellByValue());
        }

        [Test]
        public void UpdateItemSellByValue_SaffronPowderUserError_SellByAlwaysEighty()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = 1,
                    Value = 34
                }
            };

            ViksWares app = new ViksWares(Items);

            Assert.Throws<ArgumentException>(() => app.UpdateItemSellByValue());
        }

        //Unit Tests: Concert Tickets

        [Test]
        public void UpdateItemSellByValue_ConcertTickets_ValueIncreasesWhenSellByDecreases()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 14,
                    Value = 23
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(24, Items[0].Value);
            Assert.AreEqual(13, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_ConcertTickets_ValueIncreasesByTwoWhenSellByIsTenOrLess()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 10,
                    Value = 34
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(36, Items[0].Value);
            Assert.AreEqual(9, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_ConcertTickets_ValueIncreasesByThreeWhenSellByIsFiveOrLess()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 5,
                    Value = 45
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(48, Items[0].Value);
            Assert.AreEqual(4, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_ConcertTickets_ValueFallsToZeroWhenSellByIsLessThanZero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 0,
                    Value = 49
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(0, Items[0].Value);
            Assert.AreEqual(-1, Items[0].SellBy);
        }

        [Test]
        public void UpdateItemSellByValue_ConcertTickets_ValueNotMoreThanFifty()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 3,
                    Value = 49
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(50, Items[0].Value);
        }

        //Unit Tests: Refrigerated Item

        [Test]
        public void UpdateItemSellByValue_RefrigeratedItem_ValueDecreasesByTwoWhenSellByDecreases()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated Milk",
                    SellBy = 3,
                    Value = 21
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(2, Items[0].SellBy);
            Assert.AreEqual(19, Items[0].Value);
        }
        
        [Test]
        public void UpdateItemSellByValue_RefrigeratedItem_ValueDoesNotDecreaseMoreThanZero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated Milk",
                    SellBy = 6,
                    Value = 1
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(5, Items[0].SellBy);
            Assert.AreEqual(0, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_RefrigeratedItem_ValueDoesNotDecreaseMoreThanZeroWhenSellByLessThanZero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated Milk",
                    SellBy = -1,
                    Value = 1
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(-2, Items[0].SellBy);
            Assert.AreEqual(0, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_RefrigeratedItem_ValueDecreasesByFourWhenSellByLessThanZero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated Milk",
                    SellBy = -1,
                    Value = 5
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(-2, Items[0].SellBy);
            Assert.AreEqual(1, Items[0].Value);
        }

        [Test]
        public void UpdateItemSellByValue_RefrigeratedItem_BehaviourSameForDifferentRefrigeratedItem()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Refrigerated Meat",
                    SellBy = 5,
                    Value = 3
                }
            };

            ViksWares app = new ViksWares(Items);

            app.UpdateItemSellByValue();

            Assert.AreEqual(4, Items[0].SellBy);
            Assert.AreEqual(1, Items[0].Value);
        }

    }
}