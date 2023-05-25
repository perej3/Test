using System;
using System.Collections.Generic;

namespace csharp
{
    public class ViksWares
    {
        IList<Item> items;
        public ViksWares(IList<Item> Items)
        {
            this.items = Items;
        }
        public void UpdateItemSellByValue()
        {
            for (var i = 0; i < items.Count; i++)
            {
                ValidateUserData(items, i);

                if (items[i].Name.ToLower() == "saffron powder") continue;

                items[i].SellBy--;

                if (items[i].Name.ToLower().Contains("refrigerated")) UpdateRefrigeratedItem(items, i);

                else if (items[i].Name.ToLower().Contains("concert tickets")) UpdateConcertTicketsItem(items, i);

                else if (items[i].Name.ToLower() == "aged parmigiano") UpdateAgedParmigianoItem(items, i);

                else UpdateNormalItem(items, i);
            }
        }

        private static void UpdateNormalItem(IList<Item> item, int i)
        {

            if (item[i].SellBy < 0 && item[i].Value > 0) item[i].Value--;

            if (item[i].Value > 0) item[i].Value--;
        }

        private static void UpdateConcertTicketsItem(IList<Item> concertTicketItem, int i)
        {
            if (concertTicketItem[i].Value < 50)
            {
                concertTicketItem[i].Value++;

                if (concertTicketItem[i].SellBy < 11)
                {
                    if (concertTicketItem[i].Value < 50) concertTicketItem[i].Value++;

                    if (concertTicketItem[i].SellBy < 6)
                    {
                        if (concertTicketItem[i].Value < 50) concertTicketItem[i].Value++;
                    }
                }
            }
            
            if (concertTicketItem[i].SellBy < 0) concertTicketItem[i].Value = 0;
        }

        private static void UpdateRefrigeratedItem(IList<Item> item, int i)
        {
            item[i].Value = item[i].SellBy < 0 ? item[i].Value -= 4 : item[i].Value -= 2;

            item[i].Value = item[i].Value < 0 ? 0 : item[i].Value;
        }

        private static void UpdateAgedParmigianoItem(IList<Item> agedParmigianoItem, int i)
        {
            if (agedParmigianoItem[i].Value < 50)
            {
                if (agedParmigianoItem[i].SellBy < 0) agedParmigianoItem[i].Value++;

                agedParmigianoItem[i].Value++;
            }
        }

        // Validation of data per item (iteration)
        private static void ValidateUserData(IList<Item> item, int i)
        {
            if (string.IsNullOrWhiteSpace(item[i].Name)) throw new ArgumentException("Item name cannot be null");

            // Saffron Powder must always have a value of 80 and does not have a sell by date so should be -1
            if (item[i].Name.ToLower() == "saffron powder" && (item[i].Value != 80 || item[i].SellBy != -1))
            {
                throw new ArgumentException("Incorrect Value/SellBy for Saffron Powder: Value = " + item[i].Value + " SellBy = " + item[i].SellBy);
            }
            else if (item[i].Name.ToLower() != "saffron powder" && (item[i].Value > 50 || item[i].Value < 0))
            {
                throw new ArgumentException("Item " + item[i].Name + " cannot have more than 50: Value = " + item[i].Value);
            }
        }
    }
}

