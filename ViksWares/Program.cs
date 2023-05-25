using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome To our shop!"); //pass enum in name

            IList<Item> Items = new List<Item>{
                new Item
                {
                    Name = "Shoe Laces",
                    SellBy = 10,
                    Value = 20
                },
                new Item
                {
                    Name = "Aged Parmigiano",
                    SellBy = 2,
                    Value = 0
                },
                new Item
                {
                    Name = "Book of Resolutions",
                    SellBy = 5,
                    Value = 6
                },
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = -1,
                    Value = 80
                },
                new Item
                {
                    Name = "Saffron Powder",
                    SellBy = -1,
                    Value = 80
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 15,
                    Value = 20
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 10,
                    Value = 50
                },
                new Item
                {
                    Name = "Concert tickets to Talkins Festival",
                    SellBy = 12,
                    Value = 39
                },
                new Item
                {
                    Name = "Refrigerated milk",
                    SellBy = 3,
                    Value = 15
                }
            };

            var app = new ViksWares(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- Day " + i + " --------");
                Console.WriteLine("Name, Sell By, Value");

                foreach (Item item in Items) 
                {
                    if (item.SellBy < 0) Console.WriteLine(item + " (Expired)");

                    else Console.WriteLine(item);
                }

                Console.WriteLine("");

                app.UpdateItemSellByValue();
            }

            Console.ReadKey();
        }
    }
}