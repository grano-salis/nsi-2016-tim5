using EchoCollection.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.WebApi.Helpers
{
    public static class Helper
    {
        
        public static List<Collection> GetCollectionsMockUp()
        {
            List<Collection> collections = new List<Collection>();
            Collection col1 = new Collection()
            {
                Title = "Arnela",
                Description = "Prvi desc",
                IsPrivate = false,
                Items = GetItemsMockUp()
            };
            collections.Add(col1);
            Collection col2 = new Collection()
            {
                Title = "Almir",
                Description = "Drugi desc",
                IsPrivate = true,
                Items = GetItemsMockUp2()
            };
            collections.Add(col2);
            Collection col3 = new Collection()
            {
                Title = "Unfiled Items",
                Description = "Items without specific collection",
                IsPrivate = false,
                Items = new List<Item>()
            };
            collections.Add(col3);
            Collection col4 = new Collection()
            {
                Title = "Trash",
                Description = "Deleted Items",
                IsPrivate = true,
                Items = new List<Item>()
            };
            collections.Add(col4);
            return collections;
        }

        public static List<Item> GetItemsMockUp()
        {
            List<Item> itemsList = new List<Item>();
            Item i1 = new Item()
            {
                Title = "My Document",
                DocumentType = "Image",
                IsPrivate = false,
                Metadata = new Models.Metadata()
                {
                    Abstract = "Long story short",
                    Author = "Arnela Tumbul",
                    Date = Convert.ToDateTime("11/10/2016"),
                    Extra = "Addition",
                    Language = "English",
                    Publisher = "Sarajevo",
                    Rights = "All rights",
                    Url = "https://google.com"
                }
            };
            Item i2 = new Item()
            {
                Title = "My Second Document",
                DocumentType = "Image",
                IsPrivate = false,
                Metadata = new Models.Metadata()
                {
                    Abstract = "Long story short",
                    Author = "Arnela Tumbul",
                    Date = Convert.ToDateTime("11/10/2016"),
                    Extra = "Addition",
                    Language = "English",
                    Publisher = "Sarajevo",
                    Rights = "All rights",
                    Url = "https://google.com"
                }
            };
            itemsList.Add(i1);
            itemsList.Add(i2);
            return itemsList;
        }

        public static List<Item> GetItemsMockUp2()
        {
            List<Item> itemsList = new List<Item>();
            Item i1 = new Item()
            {
                Title = "Almirko",
                DocumentType = "Image",
                IsPrivate = false,
                Metadata = new Models.Metadata()
                {
                    Abstract = "Long story short",
                    Author = "Arnela Tumbul",
                    Date = Convert.ToDateTime("11/10/2016"),
                    Extra = "Addition",
                    Language = "English",
                    Publisher = "Sarajevo",
                    Rights = "All rights",
                    Url = "https://google.com"
                }
            };
            itemsList.Add(i1);
            return itemsList;
        }
    }
}